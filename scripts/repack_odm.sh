#!/bin/bash

if [ -e "./Projects/$PROJECT/Build/odm/" ]; then
    echo "Odm folder detected!"
else
    echo "Odm folder NOT DETECTED!"
    echo "Please unpack a super.img first!"
    sleep 2
    exit 0
fi


echo "Building Odm Image..."
sudo rm -rf /media/odm/
sudo mkdir /media/odm/
dd if=/dev/zero of=./Projects/$PROJECT/Output/odm.img bs=4096 count=1124
sudo mkfs.ext4 ./Projects/$PROJECT/Output/odm.img
sudo mount ./Projects/$PROJECT/Output/odm.img /media/odm/
sudo cp ./Projects/$PROJECT/Build/odm/* -r /media/odm/
sudo umount /media/odm/

echo "Check Projects/$PROJECT/Output for odm.img"
echo "Done!"

sleep 1
