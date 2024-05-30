#!/bin/bash

# Script to mount the partitions in all projects.

# Loop through all projects and mount the partitions

cd ./Projects/$PROJECT/Output/

echo "Mounting partitions..."

sudo mount -t ext4 -o loop system.img ../Build/system/
sudo mount -t ext4 -o loop product.img ../Build/product/
sudo mount -t ext4 -o loop vendor.img ../Build/vendor/
sudo mount -t ext4 -o loop odm.img ../Build/odm/
sudo mount -t ext4 -o loop prism.img ../Build/prism/ > /dev/null 2>&1
sudo mount -t ext4 -o loop optics.img ../Build/optics/ > /dev/null 2>&1

cd ../../..



