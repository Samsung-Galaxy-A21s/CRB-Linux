#!/bin/bash

echo "          "
echo "Specify path to where the optics img is located"
read -p "PATH: " optics_img_path
echo ""

if [ -e "$optics_img_path/optics.img" ]; then

    mkdir -p ./Projects/$PROJECT/Build/optics/

    echo "optics.img located!"
    echo "Copying to CRB..."
    cp -f $optics_img_path/optics.img ./Projects/$PROJECT/Input/

    FILE_TYPE=$(file ./Projects/$PROJECT/Input/optics.img)

    # Check if the file is sparse
    if echo "$FILE_TYPE" | grep -q "Android sparse image"; then

        simg2img ./Projects/$PROJECT/Input/optics.img ./Projects/$PROJECT/Output/optics.img

        echo "Extracting filesystem..."
        sudo mount -t ext4 -o loop ./Projects/$PROJECT/Output/optics.img ./Projects/$PROJECT/Build/optics/

        echo "Done, any changed made to the optics filesystem will be reflected in the optics.img file,
        located at ./Projects/$PROJECT/Output/optics.img"

    fi

fi