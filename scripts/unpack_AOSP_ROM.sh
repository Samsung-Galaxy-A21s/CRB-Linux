#!/bin/bash

echo "          "
echo "Specify your AOSP zip"
read -p "PATH: " AOSP_ROM_ZIP
echo ""

# e.g /home/thomas/a21s/LineageOS/out/target/product/a21s/lineage-19.1-20240614-UNOFFICIAL-a21s.zip

if [ -e "$AOSP_ROM_ZIP" ]; then

    echo "AOSP ROM located!"
    echo "Copying to CRB..."
    cp -f $AOSP_ROM_ZIP ./Projects/$PROJECT/Input/

    echo ""
    echo "Unpacking zip..."
    cd Projects/$PROJECT/Input/
    unzip -o *.zip

    echo ""
    echo "Decompressing brotli files..."
    
    for file in *.br; do
        brotli -d $file
    done

    echo ""
    echo "Converting sparse images to raw images..."
    ./../../../tools/sdat2img/sdat2img.py system.transfer.list system.new.dat system.img
    ./../../../tools/sdat2img/sdat2img.py vendor.transfer.list vendor.new.dat vendor.img
    ./../../../tools/sdat2img/sdat2img.py product.transfer.list product.new.dat product.img
    ./../../../tools/sdat2img/sdat2img.py odm.transfer.list odm.new.dat odm.img

    echo ""
    mv system.img ../Output/
    mv vendor.img ../Output/
    mv product.img ../Output/
    mv odm.img ../Output/

    cd ..
    mkdir -p ./Build/system/
    mkdir -p ./Build/product/
    mkdir -p ./Build/vendor/
    mkdir -p ./Build/odm/

    echo "Extracting system filesystem..."
    sudo mount -t ext4 -o loop Output/system.img Build/system/

    echo "Extracting product filesystem..."
    sudo mount -t ext4 -o loop Output/product.img Build/product/

    echo "Extracting vendor filesystem..."
    sudo mount -t ext4 -o loop Output/vendor.img Build/vendor/

    echo "Extracting odm filesystem..."
    sudo mount -t ext4 -o loop Output/odm.img Build/odm/ 

    mkdir -p ./Output/AOSP_ROM/

    echo "Copying final files to Output..."
    cp -f ./Input/*.patch.dat ./Output/AOSP_ROM/
    cp -f ./Input/recovery.img ./Output/AOSP_ROM/
    cp -f ./Input/vbmeta.img ./Output/AOSP_ROM/
    cp -f ./Input/dtbo.img ./Output/AOSP_ROM/
    cp -f ./Input/boot.img ./Output/AOSP_ROM/
    cp -f ./Input/dynamic_partitions_op_list ./Output/AOSP_ROM/

    cp -f -r ./Input/META-INF ./Output/AOSP_ROM/
    cp -f -r ./Input/install ./Output/AOSP_ROM/

    echo ""
    echo "Done!"
else
    echo -e "${BOLD_RED}[Error 1] Incorrect path specified!"
    echo -e "Check this is an AOSP packaged ROM!"
    echo -e "Check you included the file name"
    echo -e "Check you didn't include '~' at the start!${RESET}"
    exit 0
fi

sleep 2