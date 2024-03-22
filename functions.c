#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>

void newProject()
{
    char name[50];
    printf("Enter a project name: ");
    scanf("%s", &name);

    char command0[1000]; // Adjust the size as needed
    snprintf(command0, sizeof(command0),
             "[ -d \"./Projects/%s/\" ] && echo \"[Error 1] Project already "
             "exists\" && exit",
             name);
    system(command0);

    char command1[1000]; // Adjust the size as needed
    snprintf(command1, sizeof(command1), "mkdir -p Projects/%s/Input", name);
    system(command1);

    char command2[1000]; // Adjust the size as needed
    snprintf(command2, sizeof(command2), "mkdir -p Projects/%s/Output", name);
    system(command2);

    char command3[1000]; // Adjust the size as needed
    snprintf(command3, sizeof(command3), "mkdir -p Projects/%s/Build", name);
    system(command3);
}

void cleanup()
{
    char confirm;
    printf("You are about to delete ALL projects\n");
    printf("Are you sure you want to continue? [Y/N]: ");

    // Consume the newline character left in the input buffer
    while (getchar() != '\n')
        ;

    scanf("%c", &confirm);

    if (confirm == 'Y' || confirm == 'y')
    {
        printf("\nDeleting...");
        system("rm -rf Projects/\*");
        printf("\n");
    }
    else if (confirm == 'N' || confirm == 'n')
    {
        printf("\nNOT Deleting Projects folder\n");
        exit(0);
    }
    else
    {
        printf("\n[Error 1] Invalid Option!\n");
    }
}

void unpackSuper()
{
    // List projects available to choose from
    char project[100];
    printf("Choose one of the following projects below:\n\n");
    system("ls Projects/");

    printf("\nOption: ");
    scanf("%s", &project);

    char command4[1000]; // Adjust the size as needed
    snprintf(command4, sizeof(command4),
             "[ ! -d \"Projects/%s/\" ] && echo \"[Error 1] This Projects does "
             "NOT exist!\" && exit",
             project);
    system(command4);

    char superPath[1000];
    printf("\nSpecify the FULL path to the folder where the super.img is "
           "located!\n");
    printf("PATH: ");
    scanf("%s", &superPath);

    char command5[10000]; // Adjust the size as needed
    snprintf(command5, sizeof(command5),
             "[ ! -f \"%ssuper.img\" ] && echo \"[Error 1] Super.img not "
             "found!\" && exit",
             superPath);
    system(command5);

    system("echo \"Copying super.img to CRB...\"");

    char command6[10000]; // Adjust the size as needed
    snprintf(command6, sizeof(command6), "cp -f %ssuper.img Projects/%s/Input/super.img", superPath, project);
    system(command6);
}

void startChoice(int choice)
{
    switch (choice)
    {
    case 1:
        newProject();
        break;
    case 2:
        cleanup();
        break;
    case 3:
        unpackSuper();
        break;
    case 4:
        printf("This feature is not currently available!\n");
        break;
    case 5:
        printf("This feature is not currently available!\n");
        break;
    case 6:
        printf("This feature is not currently available!\n");
        break;
    case 7:
        printf("This feature is not currently available!\n");
        break;
    case 8:
        printf("This feature is not currently available!\n");
        break;
    case 9:
        printf("This feature is not currently available!\n");
        break;
    case 10:
        printf("This feature is not currently available!\n");
        break;
    case 11:
        exit(0);
        break;
    }
}
