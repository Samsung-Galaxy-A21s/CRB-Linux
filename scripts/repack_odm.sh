#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/odm/" ]; then
    echo "Odm folder detected!"
else
    echo "Odm folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

ODM_SIZE=$(du -b ./Projects/$PROJECT/Input/odm.img | awk '{print $1}')
BLOCK_SIZE=$(stat -f ./Projects/$PROJECT/Input/super.img | grep "Block size:" | awk '{print $3}')

CALCULATED_ODM_SIZE=$(echo "($ODM_SIZE / $BLOCK_SIZE)" | bc)

echo "Building Odm Image..."
sudo rm -rf /media/odm/
sudo mkdir /media/odm/
sudo rm -rf ./Projects/$PROJECT/Output/odm.img
dd if=/dev/zero of=./Projects/$PROJECT/Output/odm.img bs=$BLOCK_SIZE count=$CALCULATED_ODM_SIZE
sudo mkfs.ext4 ./Projects/$PROJECT/Output/odm.img
sudo mount ./Projects/$PROJECT/Output/odm.img /media/odm/
sudo cp ./Projects/$PROJECT/Build/odm/* -r /media/odm/

# Needs to be stalled for a bit to ensure the copy is done
sleep 1.5

sudo umount /media/odm/

echo "Check Projects/$PROJECT/Output for odm.img"
echo "Done!"

sleep 1
