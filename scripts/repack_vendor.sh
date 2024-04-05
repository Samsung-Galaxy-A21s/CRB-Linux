#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/vendor/" ]; then
    echo "Vendor folder detected!"
else
    echo "Vendor folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

echo "Building Vendor Image..."
sudo rm -rf /media/vendor/
sudo mkdir /media/vendor/
dd if=/dev/zero of=./Projects/$PROJECT/Output/vendor.img bs=4096 count=139121
sudo mkfs.ext4 ./Projects/$PROJECT/Output/vendor.img
sudo mount ./Projects/$PROJECT/Output/vendor.img /media/vendor/
sudo cp ./Projects/$PROJECT/Build/vendor/* -r /media/vendor/
sudo umount /media/vendor/

echo "Check Projects/$PROJECT/Output for vendor.img"
echo "Done!"

sleep 1
