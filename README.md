# ConsoleCache
Simple LRU cache implementation.
Console-based and kind of event-driven. 

Examples of available commands:
- get 3 (returns cached value by key. if there's no such key in cache returns -1)
- put 2 2 (adds a key value pair to cache)
- print (prints all cached key-value pairs)

Get it up and running with Docker:
```bash 
docker build -t console-cache .
docker run -it console-cache
```
[![.NET](https://github.com/lvchkn/ConsoleCache/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/lvchkn/ConsoleCache/actions/workflows/dotnet.yml)
