# ConsoleCache
[![.NET](https://github.com/lvchkn/ConsoleCache/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/lvchkn/ConsoleCache/actions/workflows/build-and-test.yml)

Simple console-based LRU cache implementation.

Examples of available commands:
- get 3 (returns cached value by key. if there's no such key in cache returns -1)
- set 2 2 (adds a key value pair to cache)
- print (prints all cached key-value pairs)

Get it up and running with Docker:
```bash 
docker build -t console-cache .
docker run -it console-cache
```
