---
title: Photo with handwritten numbers on a binary image
---

Folder `cisla_ver`contains images of numbers.

![](/zodoc/media/cisla_ver.jpg)
Task
====
Convert an image into a binary representation, where the white numbers will be individual and the black background.

# Read an image
Image = imread ('cisla_ver.jpg');
imshow (Image)
![](../media/2018-11-14-22-32-00.jpg)
# Convert image to binary
 BW = im2bw(B,0.5); 
 imshow(BW)
![](../media/2018-11-14-22-32-32.jpg)
# Erode image
 se = strel('line',10,90);
 erodedBW = imerode(BW, se);
 imshow(erodedBW);
   Create a structured element. And use the imerode feature that splits the object into simpler parts. 
![](E:\zodoc\2018-11-14-22-33-15.jpg)
 
# White numbers and black background
bw2 = imcomplement(BW);
imshow(bw2)
![](../media/2018-11-14-22-33-25.jpg)
