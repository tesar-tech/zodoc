title: PNG vs JPG
description: Comparing .png and .jpg formats
---
>This document works with MATLAB built-in image *coloredChips.png* in `A` variable. The code uses `A` to create images in an **imgs/** folder.
# Creating an image database
* To compare atributes of both formats, following code will create database of 100 **.jpg** and 100 **.png** images of *coloredChips.png*, varying in size
* It would be more educative to use a database of diverse pictures, but for simplicity, we use this solution. Results of this chapter would be no different: The plot shows, that using **.jpg** is more space-saving than using **.png**
* First create **imgs/** folder in your actual working directory
``` matlab
clear all 

route= 'imgs/'; %sets route to saving directory
A=imread('coloredChips.png'); %reads an image

for i=1:100
	pic_res=imresize(A,i/100); %img resize
	[r, c]=size(pic_res);
	pic_size(i,1)=r*c; %size of current img in pixels

	imwrite(pic_res,[route ,'pic_' num2str(i/100) '.jpg'],'JPEG'); %saving current img in .png
	imwrite(pic_res,[route, 'pic_' num2str(i/100) '.png'],'PNG'); %saving current img in .jpg
end
```
# Loading of .jpg images
``` matlab
B = dir([route,'*.jpg']); % load all .jpg images into B 
B_count= length(B); % number of .jpg images
index = 1;
```
# Counting pixels and bytes of each .jpg image
``` matlab
for img_Index = 1: B_count
	act_img = B(img_Index);
	
	if(~act_img.isdir)
		act_img_name = act_img.name;
		A = imread([route,act_img_name]);
		[a,b] = size(A);	
		byte_count(index)= act_img.bytes;
		px_count(index) = a*b;
		index = index +1;
	end
end

px_count_jpg = px_count;
byte_count_jpg = byte_count;
```
# Loading of .png images
``` matlab
B = dir([route,'*.png']); % load all .png images into B 
B_count= length(B); % number of .png images
index = 1;
```
# Counting pixels and bytes of each .png image
``` matlab
for img_Index = 1: B_count
act_img = B(img_Index);

	if(~act_img.isdir)
	act_img_name = act_img.name; 
 	A = imread([route,act_img_name]);
	[a,b] = size(A);
	byte_count(index)= act_img.bytes;
	px_count(index) = a*b;
	index = index +1;
	end
end

px_count_png = px_count;
byte_count_png = byte_count;
```
# Plotting the relationship between pixels count and file size of .jpg and .png images
``` matlab
scatter( px_count_jpg,byte_count_jpg/1024,'b');xlabel('pixels'), ylabel('kilobytes')
hold on
scatter( px_count_png,byte_count_png/1024,'r');xlabel('pixels'), ylabel('kilobytes')
legend('jpg','png') 
```
![](media/pvj1.png)