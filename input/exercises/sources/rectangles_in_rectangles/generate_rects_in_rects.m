imsizemin = 100;
imsizemax = 200;

imgnum = 20;

for ii = 1:imgnum
    
    %generate random colors for background and foreground
    rnd_background_color = 0;
    rnd_foreground_color=0;
    while(isequal(rnd_background_color,rnd_foreground_color))%anti-same-colors guard
        rnd_background_color = [randi([0 255],1),randi([0 255],1),randi([0 255],1)];
        rnd_foreground_color = [randi([0 255],1),randi([0 255],1),randi([0 255],1)];
    end
    
    %random size of background
    bg_width = randi([imsizemin,imsizemax],1);
    bg_height = randi([imsizemin,imsizemax],1);
    
    %create background with random color
    bg_one_channel_ones = ones(bg_width,bg_height);
    background = uint8(cat(3, bg_one_channel_ones*rnd_background_color(1),...
        bg_one_channel_ones*rnd_background_color(2),...
        bg_one_channel_ones*rnd_background_color(3)));
    
    %random size of foreground (smaller than background)
    fg_width = randi([2,bg_width-2],1);% "-2" means do not touch edges
    fg_height =randi([2,bg_height-2],1);
    
    %foregorund size reduction
%     fg_width = round(fg_width * rand(1)*0.9+0.1);% +.1 -> no less than .1;*.9 -> no more than 1
%     fg_height = round(fg_height *rand(1)*0.9 +0.1);
%     
    %create foreground wih random color
    fg_one_channel_ones = ones(fg_width,fg_height);
    foreground = uint8(cat(3, fg_one_channel_ones*rnd_foreground_color(1),...
        fg_one_channel_ones*rnd_foreground_color(2),...
        fg_one_channel_ones*rnd_foreground_color(3)));
    
    %count placing of foreground
    width_padding_left = randi([2, bg_width - fg_width],1);
    height_padding_top = randi([2,bg_height - fg_height],1);
    
    %place foreground to background
    background(width_padding_left:size(foreground,1)+width_padding_left-1,...
        height_padding_top:size(foreground,2)+height_padding_top-1,:)...
        = foreground;
    
    %save image to file
    imwrite(background,['./imgs/img_' num2str(ii,'%03i'),'.png'])
    disp(['image ' num2str(ii,'%03i') ' saved']);
    
end


