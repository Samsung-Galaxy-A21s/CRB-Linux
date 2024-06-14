#!/bin/bash

if [ -e "./Projects/$PROJECT/Output/system.img" ] && [ -e "./Projects/$PROJECT/Output/product.img" ] && [ -e "./Projects/$PROJECT/Output/vendor.img" ] && [ -e "./Projects/$PROJECT/Output/odm.img" ] && [ -e "./Projects/$PROJECT/Output/AOSP_ROM/boot.img" ] && [ -e "./Projects/$PROJECT/Output/AOSP_ROM/vbmeta.img" ] && [ -e "./Projects/$PROJECT/Output/AOSP_ROM/recovery.img" ]; then
    echo ""
    echo "AOSP ROM data detected!"
    echo ""

    ./scripts/unmount.sh

    echo "Building AOSP ROM..."
    cd ./Projects/$PROJECT/Output/

    img2simg system.img system.sparse
    img2simg product.img product.sparse
    img2simg vendor.img vendor.sparse
    img2simg odm.img odm.sparse

    ./../../../tools/img2sdat/img2sdat.py system.sparse -o ./AOSP_ROM/ -v 4
    ./../../../tools/img2sdat/img2sdat.py vendor.sparse -o ./AOSP_ROM/ -v 4
    ./../../../tools/img2sdat/img2sdat.py product.sparse -o ./AOSP_ROM/ -v 4
    ./../../../tools/img2sdat/img2sdat.py odm.sparse -o ./AOSP_ROM/ -v 4

    cd AOSP_ROM/
    zip -r CRB-AOSP-PACKAGED-ROM.zip *

    echo ""
    echo "ROM has been built and is located at: Projects/$PROJECT/Output/AOSP_ROM/CRB-AOSP-PACKAGED-ROM.zip"
    cd ..
    rm -rf *.sparse
    echo "Done!"



else
    echo ""
    echo -e "${BOLD_RED}[Error 1] AOSP ROM data NOT DETECTED!"
    echo -e "Please Unpack a ROM first!"
    echo -e "*hint* Also check the partitions are mounted!${RESET}"
    sleep 2
    exit 0
fi