#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/product/" ]; then
    echo "Product folder detected!"
else
    echo "Product folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

echo "Building Product Image..."
sudo rm -rf /media/product/
sudo mkdir /media/product/
dd if=/dev/zero of=./Projects/$PROJECT/Output/product.img bs=4096 count=278141
sudo mkfs.ext4 ./Projects/$PROJECT/Output/product.img
sudo mount ./Projects/$PROJECT/Output/product.img /media/product/
sudo cp ./Projects/$PROJECT/Build/product/* -r /media/product/
sudo umount /media/product/

echo "Check Projects/$PROJECT/Output for product.img"
echo "Done!"

sleep 1
