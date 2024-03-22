#!/bin/bash
# Script to repack the Images


if [ -e ./tools/check_dir ]; then
    :
else
    echo "You are not in the correct director!"
    echo "Stopping program now!"
    exit 0
fi

echo "Projects: "
echo "          "
_all_projects=$(ls ./Projects)
echo "$_all_projects"

echo "      "
echo "Select a Project from the following above,"
read -p "*WARNING* It is CASE sensitive: " project_option
echo "$project_option has been selected"

echo ""
echo "Do you want to select image(s) to repack[1] or repack all images[2]: "
read -p "Choice: " choice
if [[ $choice == [1] ]]; then
    read -p "Build System Image?[Y/N]: " system_choice
    read -p "Build Product Image?[Y/N]: " product_choice
    read -p "Build Vendor Image?[Y/N]: " vendor_choice
    read -p "Build Odm Image?[Y/N]: " odm_choice
    read -p "Build Super Image?[Y/N]: " super_choice
    echo ""
elif [[ $choice == [2] ]]; then
    :
else
    echo "Invalid Choice!"
    exit 0
fi

if [[ $system_choice == [yY] || $choice == [2] ]]; then
    echo "Building System Image..."
    sudo rm -rf /media/system/
    sudo mkdir /media/system/
    dd if=/dev/zero of=./Projects/$project_option/Output/system.img bs=4096 count=978543
    sudo mkfs.ext4 ./Projects/$project_option/Output/system.img
    sudo mount ./Projects/$project_option/Output/system.img /media/system/
    sudo cp ./Projects/$project_option/Build/system/* -r /media/system/
    sudo umount /media/system/
fi

if [[ $product_choice == [yY] || $choice == [2] ]]; then
    echo "Building Product Image..."
    sudo rm -rf /media/product/
    sudo mkdir /media/product/
    dd if=/dev/zero of=./Projects/$project_option/Output/product.img bs=4096 count=278141
    sudo mkfs.ext4 ./Projects/$project_option/Output/product.img
    sudo mount ./Projects/$project_option/Output/product.img /media/product/
    sudo cp ./Projects/$project_option/Build/product/* -r /media/product/
    sudo umount /media/product/
fi

if [[ $vendor_choice == [yY] || $choice == [2] ]]; then
    echo "Building Vendor Image..."
    sudo rm -rf /media/vendor/
    sudo mkdir /media/vendor/
    dd if=/dev/zero of=./Projects/$project_option/Output/vendor.img bs=4096 count=139121
    sudo mkfs.ext4 ./Projects/$project_option/Output/vendor.img
    sudo mount ./Projects/$project_option/Output/vendor.img /media/vendor/
    sudo cp ./Projects/$project_option/Build/vendor/* -r /media/vendor/
    sudo umount /media/vendor/
fi

if [[ $odm_choice == [yY] || $choice == [2] ]]; then
    echo "Building Odm Image..."
    sudo rm -rf /media/odm/
    sudo mkdir /media/odm/
    dd if=/dev/zero of=./Projects/$project_option/Output/odm.img bs=4096 count=1124
    sudo mkfs.ext4 ./Projects/$project_option/Output/odm.img
    sudo mount ./Projects/$project_option/Output/odm.img /media/odm/
    sudo cp ./Projects/$project_option/Build/odm/* -r /media/odm/
    sudo umount /media/odm/
fi

if [[ $super_choice == [yY] || $choice == [2] ]]; then
    echo "Building Super Image..."
    echo ""
    _OUTPUT=./Projects/$project_option/Output
    ./tools/super_to_raw/lpmake --metadata-size 65536 --super-name super --metadata-slot 1 --device super:6131421184 --group main:5721821184 --partition system:readonly:4008112128:main --image system=$_OUTPUT/system.img --partition product:readonly:1139265536:main --image product=$_OUTPUT/product.img --partition vendor:readonly:569839616:main --image vendor=$_OUTPUT/vendor.img --partition odm:readonly:4603904:main --image odm=$_OUTPUT/odm.img --sparse --output $_OUTPUT/super.img
    echo ""
fi

echo "If everything suceeded Image(s) can be found in Output"
echo ""
echo "Done!"

