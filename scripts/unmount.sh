#!/bin/bash

# Script to un-mount the partitions in all projects.

cd ./Projects/$PROJECT/Build/

echo "Unmounting partitions..."

sudo umount system/
sudo umount product/
sudo umount vendor/
sudo umount odm/
sudo umount prism/ > /dev/null 2>&1
sudo umount optics/ > /dev/null 2>&1

cd ../../..