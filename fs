#!/bin/bash
# force close running pkg
source basic-method.sh
PKG_NAME=$1

if [ ! $PKG_NAME ]; then
	echo "------------------------OOPS:(  Please tell me which pkg! ------------------------"
	exit
fi

echo "------------------------Force closing $PKG_NAME ------------------------"
if [ "$dev" ]; then
        check_device
        adb -s $dev shell am force-stop $PKG_NAME
else
        adb shell am force-stop $PKG_NAME
fi