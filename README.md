#** CRB Kitchen for Linux **

## Prepare:

Update Dependencies:

    $ sudo apt update && sudo apt upgrade -y
    $ sudo apt install android-sdk-libsparse-utils -y

Download latest release from the [Releases Page](https://github.com/Samsung-Galaxy-A21s/CRB-Linux/releases)

To Build CRB-Linux from Source:

	$ git clone -b main --depth=1 https://github.com/Samsung-Galaxy-A21s/CRB-Linux && cd CRB-Linux

Then to compile:
	
	$ make
