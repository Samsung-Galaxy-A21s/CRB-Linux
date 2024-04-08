#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/system/" ]; then
    echo "System folder detected!"
else
    echo "System folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

SYSTEM_SIZE=$(sudo du -b ./Projects/$PROJECT/Build/system | tail -n 1 | awk '{print $1}')
BLOCK_SIZE=$(stat -f ./Projects/$PROJECT/Input/super.img.raw | grep "Block size:" | awk '{print $3}')

CALCULATED_SYSTEM_SIZE=$(echo "($SYSTEM_SIZE / $BLOCK_SIZE) + 41984" | bc)

echo "Building System Image..."
sudo rm -rf /media/system/
sudo mkdir /media/system/
sudo rm -rf ./Projects/$PROJECT/Output/system.img
dd if=/dev/zero of=./Projects/$PROJECT/Output/system.img bs=$BLOCK_SIZE count=$CALCULATED_SYSTEM_SIZE
sudo mkfs.ext4 ./Projects/$PROJECT//Output/system.img
sudo mount ./Projects/$PROJECT//Output/system.img /media/system/
sudo cp ./Projects/$PROJECT//Build/system/* -r /media/system/
sudo umount /media/system/
img2simg ./Projects/$PROJECT//Output/system.img ./Projects/$PROJECT//Output/system.img


echo "Check Projects/$PROJECT/Output for system.img"
echo "Done!"

sleep 1
