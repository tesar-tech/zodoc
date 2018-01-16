---
title: Connected shapes
---
``` matlab
imgs = dir('./imgs/*.png');
imnum =length(imgs);

for ii = 1:imnum
    
    curr_img_struct = imgs(ii);
    curr_img = imread(fullfile(curr_img_struct.folder,curr_img_struct.name));
    %curr_img_bw = im2bw(curr_img);% for older matlabs
    curr_img_bw = imbinarize(curr_img);
     
    
    % keep just objects with eccentricity equal 0
    
    %---solution using bwpropfilt
    curr_img_bw_new = bwpropfilt(curr_img_bw,'Eccentricity',[0 0]);
    
    %---solution using for loop
    %props = regionprops(curr_img_bw,'Eccentricity','PixelIdxList');
    %curr_img_bw_new = curr_img_bw;
    %     for region_ii = 1:length(props)
    %         if( props(region_ii).Eccentricity>0)
    %             curr_img_bw_new(props(region_ii).PixelIdxList) = 0;%set pixels of shape to black
    %         end
    %     end
    
    %%%     square and cyrcle have ecc==0
    %%%     eccentricity does not solve the issue when square is inside of
    %%%     cyrcle (or reversely)... Solution could be area/perimeter
    %%%         ratio... But eccentricity is "the easiest almost perfectly
    %%%         working solution"  ¯\_(ツ)_/¯
    
    %save images
    imwrite(curr_img_bw_new,fullfile('.', 'imgs_result', curr_img_struct.name))
    disp(['image ' curr_img_struct.name ' saved']);
    
end


```