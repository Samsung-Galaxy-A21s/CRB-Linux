#!/bin/bash

# Script to un-mount the partitions in all projects.

cd ./Projects/$PROJECT/Build/

echo ""
echo "Unmounting partitions..."
echo ""

sudo umount system/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to un-mount system.img"
  sleep 1
else
  echo "Un-mounted system.img"
fi

sudo umount product/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to un-mount product.img"
  sleep 1
else
  echo "Un-mounted product.img"
fi

sudo umount vendor/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to un-mount vendor.img"
  sleep 1
else
  echo "Un-mounted vendor.img"
fi

sudo umount odm/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to un-mount odm.img"
  sleep 1
else
  echo "Un-mounted odm.img"
fi

sudo umount prism/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to un-mount prism.img"
  sleep 1
else
  echo "Un-mounted prism.img"
fi

sudo umount optics/ > /dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Failed to un-mount optics.img"
  sleep 1
else
  echo "Un-mounted optics.img"
fi

sleep 0.5
cd ../../..