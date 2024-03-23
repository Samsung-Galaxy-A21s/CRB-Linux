CC = gcc
CFLAGS = -Wno-implicit-function-declaration

all : final

final : build.o
	$(CC) $(CCFLAGS) main.o print.o functions.o -o CRB-Linux

build.o :
	$(CC) $(CCFLAGS) -c main.c print.c functions.c

clean :
	echo "Removing all objects..."
	rm main.o print.o functions.o CRB-Linux
