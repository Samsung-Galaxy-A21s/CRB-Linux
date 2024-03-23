#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>

#include "functions.h"
#include "print.h"

static void checker()
{
    const char *filename = "./tools/checker";

    if (access(filename, F_OK) != -1)
    {
        ;
    }
    else
    {
        printf("[Error 1] Could not find ./tools/checker\n");
        printf("*hint* Check you are running this file from the correct "
               "location\n");
        exit(0);
    }
}

int main(int argc, char *argv[])
{
    // Do initial checks to make sure you are in the correct directory
    checker();

    // Check the cmd line arguements

    int choice;
    int rec = 0;

    for (int i = 1; i < argc; i++)
    {
        if ((strcmp(argv[i], "--help") == 0) || (strcmp(argv[i], "-h") == 0))
        {
            printHelp();
            rec = 1;
        }
        else if ((strcmp(argv[i], "--version") == 0) || (strcmp(argv[i], "-v") == 0))
        {
            printVersion();
            rec = 1;
        }
        else if ((strcmp(argv[i], "--start") == 0) || (strcmp(argv[i], "-s") == 0))
        {
            printStart();
            rec = 1;

            printf("Option: ");
            scanf("%d", &choice);
            startChoice(choice);
        }
        if (rec != 1)
        {
            printHelp();
        }
    }

    return 0;
}
