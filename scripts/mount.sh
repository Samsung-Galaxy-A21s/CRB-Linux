#!/bin/bash

# Script to mount the partitions in all projects.

# Loop through all projects and mount the partitions

cd ./Projects/$PROJECT/Output/

echo ""
echo "Mounting partitions..."
echo ""

sudo mount -t ext4 -o loop system.img ../Build/system/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to mount system.img"
  sleep 1
else
  echo "Mounted system.img"
fi

sudo mount -t ext4 -o loop product.img ../Build/product/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to mount product.img"
  sleep 1
else
  echo "Mounted product.img"
fi

sudo mount -t ext4 -o loop vendor.img ../Build/vendor/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to mount vendor.img"
  sleep 1
else
  echo "Mounted vendor.img"
fi

sudo mount -t ext4 -o loop odm.img ../Build/odm/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to mount odm.img"
  sleep 1
else
  echo "Mounted odm.img"
fi

sudo mount -t ext4 -o loop prism.img ../Build/prism/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to mount prism.img"
  sleep 1
else
  echo "Mounted prism.img"
fi

sudo mount -t ext4 -o loop optics.img ../Build/optics/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to mount optics.img"
  sleep 1
else
  echo "Mounted optics.img"
fi

sleep 0.5
cd ../../..



