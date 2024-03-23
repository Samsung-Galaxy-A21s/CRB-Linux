#!/bin/bash

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
