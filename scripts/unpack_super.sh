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

    FILE_TYPE=$(file super.img)

    # Check if the file is sparse
    if echo "$FILE_TYPE" | grep -q "Android sparse image"; then
        echo "Sparse image detected!"

        # Convert sparse image to raw image
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
    else
        echo "Raw image detected!"

        mv super.img super.img.raw

        echo "Extracting system image..."
        ./../../../tools/super_to_raw/lpunpack --partition=system super.img.raw
        echo "Extracting product image..."
        ./../../../tools/super_to_raw/lpunpack --partition=product super.img.raw
        echo "Extracting vendor image..."
        ./../../../tools/super_to_raw/lpunpack --partition=vendor super.img.raw
        echo "Extracting odm image..."
        ./../../../tools/super_to_raw/lpunpack --partition=odm super.img.raw
        echo ""
    fi

    cd ..
    mkdir -p ./Build/system/
    mkdir -p ./Build/product/
    mkdir -p ./Build/vendor/
    mkdir -p ./Build/odm/

    mv Input/system.img Output/
    mv Input/product.img Output/
    mv Input/vendor.img Output/
    mv Input/odm.img Output/

    echo "Extracting system filesystem..."
    sudo mount -t ext4 -o loop Output/system.img Build/system/

    echo "Extracting product filesystem..."
    sudo mount -t ext4 -o loop Output/product.img Build/product/

    echo "Extracting vendor filesystem..."
    sudo mount -t ext4 -o loop Output/vendor.img Build/vendor/

    echo "Extracting odm filesystem..."
    sudo mount -t ext4 -o loop Output/odm.img Build/odm/



    echo ""
    echo "Done!"
else
    echo -e "${BOLD_RED}[Error 1] Incorrect path specified!"
    echo -e "Check a super.img is present in the directory!"
    echo -e "Check you didn't include a '/' at the end!"
    echo -e "Check you didn't include '~' at the start!${RESET}"
    exit 0
fi

sleep 2
