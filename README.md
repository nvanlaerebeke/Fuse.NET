# Fuse.NET

## Introduction

This is a .NET 5 binding for FUSE based on [Mono.Fuse.NETStandard](https://github.com/alhimik45/Mono.Fuse.NETStandard) and is a port of [mono-fuse](https://github.com/jonpryor/mono-fuse) library.

For documentation see [here](http://www.jprl.com/Projects/mono-fuse/docs/).

## Requirements

- dotnet
- libtool
- libglib2

To install, `dotnet` on Linux, the [Microsoft Documentation](https://docs.microsoft.com/en-us/dotnet/core/install/linux)  

Install build tools:

```bash
apt install libtool-bin libglib2.0-dev
```

## Samples

To run examples clone this repository, run `build-libs.sh` and then run projects from `example/` folder.

```bash
./build-libs.sh

./example/
```