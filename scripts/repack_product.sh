#!/bin/bash

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
