title: Rectangles in Rectangles 
---
``` sql
'img_009.png'
'img_018.png'
'img_002.png'
'img_008.png'
'img_004.png'
'img_006.png'
'img_012.png'
'img_010.png'
'img_019.png'
'img_015.png'
'img_016.png'
'img_013.png'
'img_001.png'
'img_011.png'
'img_014.png'
'img_020.png'
'img_005.png'
'img_007.png'
'img_017.png'
'img_003.png'
```

``` matlab
imgs = dir('./imgs_test1/*.png');
imnum =length(imgs);
inner_rect_size = zeros(imnum,1);

for ii = 1:imnum
    
    curr_img_struct = imgs(ii);
    curr_img = imread(fullfile(curr_img_struct.folder,curr_img_struct.name));
    curr_img_double = mat2gray(curr_img);% to double in 0-1 range
    gr = rgb2gray(curr_img_double); 
    %%bw =  im2bw(gr,graythresh(gr));%for older matlabs
    bw = imbinarize(gr,graythresh(gr));
    if(bw(1,1))%if small rect is black
        bw = ~bw;%invert colors
    end
    
    inner_rect_size(ii) = sum(bw(:));%count number of ones
end

[~,indxs]= sort(inner_rect_size);%sort by size of inner rect and get indexes

sorted_images = {imgs(indxs).name}';% get sorted images by file name in cell array
```