#!/bin/bash

# Script to package a ROM

echo ""
echo "Select a following option to package:"
echo ""

echo "1. Package super.img"
echo "2. Package boot.img"
echo "3. Package super.img and boot.img"
echo "4. Package prism.img and optics.img"
echo "5. Package super.img, boot.img, prism.img and optics.img"

echo ""
read -p "CHOICE: " choice


SUPER_EXISTS()
{

    if [ -e "./Projects/$PROJECT/Output/super.img" ]; then
        :
    else
        echo "[Error 1] Super.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
    fi

}

BOOT_EXISTS()
{
    
    if [ -e "./Projects/$PROJECT/Output/boot.img" ]; then
        :
    else
        echo "[Error 1] Boot.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
    fi
}

PRISM_EXISTS()
{
        
    if [ -e "./Projects/$PROJECT/Output/prism.img" ]; then
        :
    else
        echo "[Error 1] Prism.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
    fi
}

OPTICS_EXISTS()
{
                
    if [ -e "./Projects/$PROJECT/Output/optics.img" ]; then
        :
    else
        echo "[Error 1] Optics.img not located in default directory!"
        echo "Make sure you have rebuilt one first!"
    fi
}


PACKAGE_1()
{
    SUPER_EXISTS

    echo "Building Package..."
    cp -f ./Projects/$PROJECT/Output/super.img ./tools/packaging/choice_1/

    cd ./tools/packaging/choice_1/
    zip -r CRB-RECOVERY-FLASHABLE-SUPER.zip *

    mv CRB-RECOVERY-FLASHABLE-SUPER.zip ../../../Projects/$PROJECT/Output/
    rm -rf ./super.img

    cd ../..

    echo "Done, Flashable zip located at ./Projects/$PROJECT/Output/CRB-RECOVERY-FLASHABLE-SUPER.zip"
    echo "Install via adb sideload in a custom recovery"
}

PACKAGE_2()
{
    BOOT_EXISTS

    echo "Building Package..."
    cp -f ./Projects/$PROJECT/Output/boot.img ./tools/packaging/choice_2/

    cd ./tools/packaging/choice_2/
    zip -r CRB-RECOVERY-FLASHABLE-BOOT.zip *

    mv CRB-RECOVERY-FLASHABLE-BOOT.zip ../../../Projects/$PROJECT/Output/
    rm -rf ./boot.img

    cd ../..

    echo "Done, Flashable zip located at ./Projects/$PROJECT/Output/CRB-RECOVERY-FLASHABLE-BOOT.zip"
    echo "Install via adb sideload in a custom recovery"
}

PACKAGE_3()
{
    SUPER_EXISTS
    BOOT_EXISTS

    echo "Building Package..."
    cp -f ./Projects/$PROJECT/Output/super.img ./tools/packaging/choice_3/
    cp -f ./Projects/$PROJECT/Output/boot.img ./tools/packaging/choice_3/

    cd ./tools/packaging/choice_3/
    zip -r CRB-RECOVERY-FLASHABLE-SUPER-BOOT.zip *

    mv CRB-RECOVERY-FLASHABLE-SUPER-BOOT.zip ../../../Projects/$PROJECT/Output/
    rm -rf ./super.img
    rm -rf ./boot.img

    cd ../..

    echo "Done, Flashable zip located at ./Projects/$PROJECT/Output/CRB-RECOVERY-FLASHABLE-SUPER-BOOT.zip"
    echo "Install via adb sideload in a custom recovery"
}

PACKAGE_4()
{
    PRISM_EXISTS
    OPTICS_EXISTS

    echo "Building Package..."
    cp -f ./Projects/$PROJECT/Output/prism.img ./tools/packaging/choice_4/
    cp -f ./Projects/$PROJECT/Output/optics.img ./tools/packaging/choice_4/

    cd ./tools/packaging/choice_4/
    zip -r CRB-RECOVERY-FLASHABLE-CSC.zip *

    mv CRB-RECOVERY-FLASHABLE-CSC.zip ../../../Projects/$PROJECT/Output/
    rm -rf ./prism.img
    rm -rf ./optics.img

    cd ../..

    echo "Done, Flashable zip located at ./Projects/$PROJECT/Output/CRB-RECOVERY-FLASHABLE-CSC.zip"
    echo "Install via adb sideload in a custom recovery"
}

PACKAGE_5()
{
    SUPER_EXISTS
    BOOT_EXISTS
    PRISM_EXISTS
    OPTICS_EXISTS

    echo "Building Package..."
    cp -f ./Projects/$PROJECT/Output/super.img ./tools/packaging/choice_5/
    cp -f ./Projects/$PROJECT/Output/boot.img ./tools/packaging/choice_5/
    cp -f ./Projects/$PROJECT/Output/prism.img ./tools/packaging/choice_5/
    cp -f ./Projects/$PROJECT/Output/optics.img ./tools/packaging/choice_5/

    cd ./tools/packaging/choice_5/
    zip -r CRB-RECOVERY-FLASHABLE-ROM.zip *

    mv CRB-RECOVERY-FLASHABLE-ROM.zip ../../../Projects/$PROJECT/Output/
    rm -rf ./super.img
    rm -rf ./boot.img
    rm -rf ./prism.img
    rm -rf ./optics.img

    cd ../..

    echo "Done, Flashable zip located at ./Projects/$PROJECT/Output/CRB-RECOVERY-FLASHABLE-ROM.zip"
    echo "Install via adb sideload in a custom recovery"
}

case $choice in

    1)
        PACKAGE_1
        ;;
    2)
        PACKAGE_2
        ;;
    3)
        PACKAGE_3
        ;;
    4)
        PACKAGE_4
        ;;
    5)
        PACKAGE_5
        ;;
    *)
        echo "Invalid choice"
        ;;



esac


