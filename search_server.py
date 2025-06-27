from http.server import HTTPServer, BaseHTTPRequestHandler
from urllib.parse import parse_qs, urlparse, unquote
from pathlib import Path
import difflib
import html

BASE_DIR = Path("東鋼").resolve()

class SearchHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        parsed = urlparse(self.path)
        params = parse_qs(parsed.query)
        if parsed.path == "/open":
            file_param = params.get("file", [None])[0]
            if not file_param:
                self._not_found()
                return
            target = BASE_DIR / Path(unquote(file_param))
            if target.exists() and target.is_file():
                content = target.read_text(encoding='utf-8', errors='ignore')
                self._send_html(f"<pre>{html.escape(content)}</pre>")
            else:
                self._not_found()
        elif parsed.path == "/search":
            query = params.get("q", [""])[0]
            results = self._search_files(query)
            body = [
                "<h1>規格書文件查詢</h1>",
                "<form action='/search'>",
                f"<input name='q' value='{html.escape(query)}' maxlength='60'>",
                "<input type='submit' value='Search'>",
                "</form>"
            ]
            if query:
                if results:
                    body.append("<ul>")
                    for _, p in results:
                        rel = p.relative_to(BASE_DIR).as_posix()
                        body.append(f"<li><a href='/open?file={html.escape(rel)}'>{html.escape(rel)}</a></li>")
                    body.append("</ul>")
                else:
                    body.append("{無相關資料}")
            self._send_html("".join(body))
        else:
            self.send_response(302)
            self.send_header('Location', '/search')
            self.end_headers()

    def _search_files(self, query):
        results = []
        if not query:
            return results
        for path in BASE_DIR.rglob('*'):
            if path.is_file():
                name = path.name
                ratio = difflib.SequenceMatcher(None, query, name).ratio()
                if query.lower() in name.lower() or ratio > 0.5:
                    results.append((ratio, path))
        results.sort(key=lambda x: -x[0])
        return results

    def _send_html(self, body):
        content = f"<html><body>{body}</body></html>".encode('utf-8')
        self.send_response(200)
        self.send_header('Content-Type', 'text/html; charset=utf-8')
        self.send_header('Content-Length', str(len(content)))
        self.end_headers()
        self.wfile.write(content)

    def _not_found(self):
        self.send_response(404)
        self.send_header('Content-Type', 'text/html; charset=utf-8')
        self.end_headers()
        self.wfile.write('{無相關資料}'.encode('utf-8'))

if __name__ == '__main__':
    port = 8000
    httpd = HTTPServer(('localhost', port), SearchHandler)
    print(f"Serving on http://localhost:{port}/search")
    httpd.serve_forever()
