#!/bin/bash
# force close running pkg
source basic-method.sh

PKG_NAME=$1

if [ ! $PKG_NAME ]; then
    PKG_NAME=$(get_current_pkg)
fi

echo "------------------------Force closing $PKG_NAME ------------------------"
if [ "$dev" ]; then
        check_device
        adb -s $dev shell am force-stop $PKG_NAME
else
        adb shell am force-stop $PKG_NAME
fi