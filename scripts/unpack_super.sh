#!/bin/bash
# Script to unpack a super.img file

echo "          "
echo "Specify path to where the super img is located"
read -p "PATH: " super_img_path
echo ""

if [ -e "$super_img_path/super.img" ]; then
    echo "Super.img located!"
    echo "Copying to CRB..."
    cp -f $super_img_path/super.img ./Projects/$PROJECT/Input/

    echo ""
    echo "Extracting Dynamic Partitions..."
    cd Projects/$PROJECT/Input/
    simg2img super.img super.img.raw
    echo "Extracting system image..."
    ./../../../tools/super_to_raw/lpunpack --partition=system super.img.raw
    echo "Extracting product image..."
    ./../../../tools/super_to_raw/lpunpack --partition=product super.img.raw
    echo "Extracting vendor image..."
    ./../../../tools/super_to_raw/lpunpack --partition=vendor super.img.raw
    echo "Extracting odm image..."
    ./../../../tools/super_to_raw/lpunpack --partition=odm super.img.raw
    echo ""

    cd ..
    mkdir -p ./Build/system/
    mkdir -p ./Build/product/
    mkdir -p ./Build/vendor/
    mkdir -p ./Build/odm/

    mkdir -p ./Build/.tmp_system/
    mkdir -p ./Build/.tmp_product/
    mkdir -p ./Build/.tmp_vendor/
    mkdir -p ./Build/.tmp_odm/


    echo "Extracting system filesystem..."
    sudo mount -t ext4 -o loop Input/system.img Build/.tmp_system/
    sudo cp -f Build/.tmp_system/* Build/system/ -r
    sudo umount Build/.tmp_system/
    sudo rm -rf Build/.tmp_system/
    echo "Extracting product filesystem..."
    sudo mount -t ext4 -o loop Input/product.img Build/.tmp_product/
    sudo cp -f Build/.tmp_product/* Build/product/ -r
    sudo umount Build/.tmp_product/
    sudo rm -rf Build/.tmp_product/
    echo "Extracting vendor filesystem..."
    sudo mount -t ext4 -o loop Input/vendor.img Build/.tmp_vendor/
    sudo cp -f Build/.tmp_vendor/* Build/vendor/ -r
    sudo umount Build/.tmp_vendor/
    sudo rm -rf Build/.tmp_vendor/
    echo "Extracting odm filesystem..."
    sudo mount -t ext4 -o loop Input/odm.img Build/.tmp_odm/
    sudo cp -f Build/.tmp_odm/* Build/odm/ -r
    sudo umount Build/.tmp_odm/
    sudo rm -rf Build/.tmp_odm/

    echo ""
    echo "Done!"
else
    echo "Incorrect path specified!"
    echo "Check a super.img is present in the directory!"
    echo "Check you didn't include a '/' at the end!"
    echo "Check you didn't include '~' at the start!"
    exit 0
fi

sleep 2
