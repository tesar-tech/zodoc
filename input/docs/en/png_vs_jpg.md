title: PNG vs JPG
description: Comparing .png and .jpg formats
---
>This document works with MATLAB built-in image *coloredChips.png* in `A` variable. The code uses `A` to create images in an **imgs/** folder.
# Creating an image database
* To compare atributes of both formats, following code will create database of 100 **.jpg** and 100 **.png** images of *coloredChips.png*, varying in size
* It would be more educative to use a database of diverse pictures, but for simplicity, we use this solution. Results of this chapter would be no different: The plot shows, that using **.jpg** for this kind of image is more space-saving than using **.png**
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
# Counting pixels and bytes of each image
``` matlab
% to aviod repetitions in code, this will create a cell array with both format names
formats = {'jpg' , 'png'};

% this code will count pixels and bytes of each .jpg image in first iteration, and does the same with .png images in second iteration
for i=1: 2  
    B = dir([route, strcat('*.',formats{i})]); % load all .jpg/.png images into B 
    B_count= length(B); % number of .jpg/.png images
    index = 1;

    for img_Index = 1: B_count
        act_img = B(img_Index);          
        act_img_name = act_img.name;
        A = imread([route,act_img_name]);
        [a,b] = size(A);	
        byte_count(index)= act_img.bytes;
        px_count(index) = a*b;
        index = index +1;
    end

    px_countF{i} = px_count;  % saves counts in cell array 
    byte_countF{i} = byte_count;
end
```
# Plotting the relationship between pixels count and file size of .jpg and .png images
``` matlab
scatter( px_count_jpg,byte_count_jpg/1024,'b');xlabel('pixels'), ylabel('kilobytes')
hold on
scatter( px_count_png,byte_count_png/1024,'r');xlabel('pixels'), ylabel('kilobytes')
legend('jpg','png') 
```
![](media/pvj1.png)