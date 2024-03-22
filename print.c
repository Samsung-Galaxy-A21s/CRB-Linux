#include <stdio.h>

void printHelp() {
    printf("Usage: CRB-Linux [OPTIONS]...\n");
    printf("A brief description of what the program does.\n");
    printf("\n");
    printf("Options:\n");
    printf("  -h, --help     Display this help message\n");
    printf("  -v, --version  Display version information\n");
    printf("  -s, --start    Display General startup info\n");
}

void printStart() {
	printf("**PROJECT MANAGEMENT**\n");
    printf("1)  New Project\n");
	printf("2)  Delete Projects\n\n");

	printf("**UNPACK IMAGE**\n");
	printf("3)  Unpack super.img\n");
	printf("4)  Unpack boot.img\n\n");

	printf("**REPACK IMAGE**\n");
	printf("5)  Repack system.img\n");
	printf("6)  Repack product.img\n");
	printf("7)  Repack vendor.img\n");
	printf("8)  Repack odm.img\n");
	printf("9)  Repack super.img\n");
	printf("10) Repack boot.img\n\n");

	printf("11) Exit this menu\n\n");
}

void printVersion() {
    printf("Version 1.0\n");
}
