title: Animace binarizace obrázku s proměnlivým prahem
lead: Ukladání animace binarižačního obrázku s proměnlivým prahem jako gif
Published: 2018-01-05
Tags: [matlab, binary image, animation, gif, 
variable threshold]
datazooFiles: imgs/bw_anim.gif
prerequisites: [Matlab]
Authors: [tesar-tech, polyaand]
---
>This document utilizes [animation of flower](../media/bw_anim.gif) 
``` matlab
firstTime = 1;gifName = 'bw_anim.gif';
for ii = 1:5:256
    
   curr_img = (Ag<ii)*255;% hodnoty 0 a 255 
   [A,map] = gray2ind(curr_img,2); 
   
    if firstTime ==1%první snímek je uložen zvlášť
        imwrite(A,map,gifName,'gif','LoopCount',Inf,'DelayTime',0.001);
    firstTime = 0;
    else
        imwrite(A,map,gifName,'gif','WriteMode','append','DelayTime',0.001);
    end 
 end
 %pak zkontrolovat složku ve které pracujete, zda je gif uložen

 ```
 
