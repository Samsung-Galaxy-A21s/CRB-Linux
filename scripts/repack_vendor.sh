#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/vendor/" ]; then
    echo "Vendor folder detected!"
else
    echo "Vendor folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

VENDOR_SIZE=$(du -b ./Projects/$PROJECT/Input/vendor.img.raw | awk '{print $1}')
BLOCK_SIZE=$(stat -f ./Projects/$PROJECT/Input/super.img | grep "Block size:" | awk '{print $3}')

CALCULATED_VENDOR_SIZE=$(echo "($VENDOR_SIZE / $BLOCK_SIZE) + 11776" | bc)

echo "Building Vendor Image..."
sudo rm -rf /media/vendor/
sudo mkdir /media/vendor/
sudo rm -rf ./Projects/$PROJECT/Output/vendor.img
dd if=/dev/zero of=./Projects/$PROJECT/Output/vendor.img.raw bs=$BLOCK_SIZE count=$CALCULATED_VENDOR_SIZE
sudo mkfs.ext4 ./Projects/$PROJECT/Output/vendor.img.raw
sudo mount ./Projects/$PROJECT/Output/vendor.img.raw /media/vendor/
sudo cp ./Projects/$PROJECT/Build/vendor/* -r /media/vendor/
sudo umount /media/vendor/
img2simg ./Projects/$PROJECT/Output/vendor.img.raw ./Projects/$PROJECT/Output/vendor.img
rm ./Projects/$PROJECT/Output/vendor.img.raw

echo "Check Projects/$PROJECT/Output for vendor.img"
echo "Done!"

sleep 1
