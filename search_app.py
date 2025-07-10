import os
from flask import Flask, request, render_template, send_from_directory, abort
from urllib.parse import quote, unquote

app = Flask(__name__)

BASE_DIR = os.path.abspath('.')

# Gather all file paths
file_paths = []
for root, dirs, files in os.walk(BASE_DIR):
    for name in files:
        file_paths.append(os.path.join(root, name))

@app.route('/')
def index():
    query = request.args.get('q', '')
    results = []
    if query:
        q = query.lower()
        for path in file_paths:
            filename = os.path.basename(path)
            if q in filename.lower():
                results.append({'name': filename, 'path': path})
    return render_template('index.html', query=query, results=results)

@app.route('/view')
def view_file():
    path = request.args.get('path')
    if not path:
        abort(404)
    path = unquote(path)
    if not os.path.isfile(path) or not path.startswith(BASE_DIR):
        abort(404)
    with open(path, 'r', errors='ignore') as f:
        content = f.read()
    return render_template('view.html', filename=os.path.basename(path), content=content)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
