#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/product/" ]; then
    echo "Product folder detected!"
else
    echo "Product folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

PRODUCT_SIZE=$(du -b ./Projects/$PROJECT/Input/product.img | awk '{print $1}')
BLOCK_SIZE=$(stat -f ./Projects/$PROJECT/Input/super.img | grep "Block size:" | awk '{print $3}')

CALCULATED_PRODUCT_SIZE=$(echo "($PRODUCT_SIZE / $BLOCK_SIZE) + 13056" | bc)

echo "Building Product Image..."
sudo rm -rf /media/product/
sudo mkdir /media/product/
sudo rm -rf ./Projects/$PROJECT/Output/product.img
dd if=/dev/zero of=./Projects/$PROJECT/Output/product.img bs=$BLOCK_SIZE count=$CALCULATED_PRODUCT_SIZE
sudo mkfs.ext4 ./Projects/$PROJECT/Output/product.img
sudo mount ./Projects/$PROJECT/Output/product.img /media/product/
sudo cp ./Projects/$PROJECT/Build/product/* -r /media/product/
sudo umount /media/product/



echo "Check Projects/$PROJECT/Output for product.img"
echo "Done!"

sleep 1
