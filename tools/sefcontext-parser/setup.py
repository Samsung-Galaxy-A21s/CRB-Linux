#!/usr/bin/env python
# sefcontext_parser.py
# Copyright 2017 Jake Valletta (@jake_valletta)
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#
"""sefcontext_parser.py Setup Script"""

from __future__ import print_function
from __future__ import absolute_import
from setuptools import setup

import os


def read(fname):

    """Read file"""

    return open(os.path.join(os.path.dirname(__file__), fname)).read()

setup(
    name='sefcontext-parser',
    version='0.1.0',
    description='Module to parse compiled SEAndroid "file_context" files on Nougat+ devices',
    long_description=read('README.md'),

    url='https://github.com/jakev/sefcontext-parser',
    download_url='https://github.com/jakev/sefcontext-parser',

    author='Jake Valletta',
    author_email='javallet@gmail.com',
    license='ASL',

    classifiers=[
        'Development Status :: 4 - Beta',
        'Intended Audience :: Information Technology',
        'Topic :: Security',
        'License :: OSI Approved :: Apache Software License',
        'Operating System :: POSIX :: Linux',
        'Operating System :: Microsoft :: Windows',
        'Programming Language :: Python :: 2',
        'Programming Language :: Python :: 2.7',
        'Programming Language :: Python :: 3',
        'Programming Language :: Python :: 3.4',
        'Programming Language :: Python :: 3.5'],

    keywords='Android SELinux SEAndroid parser security Nougat file_contexts binary',

    packages=["sefcontext_parser"],

    entry_points={
      'console_scripts': [
          'sefparse = sefcontext_parser.sefcontext_parser:main'
      ]
    },
)
