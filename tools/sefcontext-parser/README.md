sefcontext_parser (sefparse)
============================

`sefcontext_parser` is a module and utility (`sefparse`) that can be used to parse/decode compiled SEAndroid "file_context.bin" files. 

About
-----
Google switched from using a cleartext "file_context" format to a binary format in Android API 24 ("Nougat"). This format was changed and expanded in API 25 and API 26 ("Oreo"). The format is documented by Google [here](https://android.googlesource.com/platform/external/selinux/+/master/libselinux/utils/sefcontext_compile.c). I was inspired to write this library based on the [sefcontext_decompile](https://github.com/wuxianlin/sefcontext_decompile) developed by GitHub user wuxianlin. The functionality is roughly the same, but is implemented in python instead of C.

Setup
-----
The following commands can be used to install `sefcontext_parser`:

    git clone https://github.com/jakev/sefcontext-parser
    cd sefcontext-parser
    sudo python setup.py install

Usage
-----
There are two ways to use this project: by importing it into your current project, or by running the `sefparse` utility from the command-line. Using `sefparse` is straightforward and can be used as follows:

    adb pull /file_contexts.bin
    sefparse file_contexts.bin

To integrate the module into an existing python project, you can use the library as follows:

    from sefcontext_parser import sefcontext_parser as sefparse

    parser = sefparse.SefContextParser("file_context.bin")
    for entry in parser.process_file():
        print "Regex=%s, Context=%s" % (entry.regex, entry.context)


Results returned by `process_file` will be sorted by regex pattern.

License
-------
`sefcontext_parser` is licened under the Apache License, Version 2.0. This means it is freely available for use and modification in a personal and professional capacity.
