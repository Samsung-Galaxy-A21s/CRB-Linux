#!/bin/bash

# Tool to make a vbmeta disabled image

echo ""
echo "Provide the path to the image,
Don't include a '/' at the end of the path"
echo ""

read -p "PATH: " image

if [ -e $image/vbmeta.img ]; then
    echo ""
    echo "vbmeta.img found, disabling it..."
    echo ""

    # Logic to it
    cp $image/vbmeta.img ./Projects/$PROJECT/Output
    ./tools/vbmeta/arm64-v8a/vbmeta-disable-verification ./Projects/$PROJECT/Output/vbmeta.img
    echo ""
    echo "Check Projects/$PROJECT/Output for the disabled vbmeta.img file."
    sleep 1
    echo "Done!"
    echo ""
    echo ""
else
    echo ""
    echo "vbmeta.img not found!"
    echo ""
fi