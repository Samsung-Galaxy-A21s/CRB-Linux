#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/system/" ]; then
    echo "System folder detected!"
else
    echo "System folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi

echo "Building System Image..."
sudo rm -rf /media/system/
sudo mkdir /media/system/
dd if=/dev/zero of=./Projects/$PROJECT/Output/system.img bs=4096 count=978543
sudo mkfs.ext4 ./Projects/$PROJECT//Output/system.img
sudo mount ./Projects/$PROJECT//Output/system.img /media/system/
sudo cp ./Projects/$PROJECT//Build/system/* -r /media/system/
sudo umount /media/system/

echo "Check Projects/$PROJECT/Output for system.img"
echo "Done!"

sleep 1
