<p>Tento návod pracuje s <a href="[/zodoc/assets/img/kytka256.jpg](https://tesar-tech.github.io/zodoc/assets/img/kytka256.jpg)">obrázkem</a> uloženém v proměnné <code>A</code></p>

</blockquote>

<h1 id="load-and-show-image">Načti a zobraz obrázek</h1>

<pre><code class="language-matlab">A=imread('kytka256.jpg');

imshow(A)

</code></pre>

<p><img src="[/zodoc/assets/img/kytka256.jpg](https://tesar-tech.github.io/zodoc/assets/img/kytka256.jpg)" class="img-fluid" alt=""></p>

<p>Obrázek musí být ve složce, s kterou pracujeme!</p>

<h1 id="convert-rgb-image-to-grayscale">Převeďte obrázek RGB do šedotónu</h1>

<pre><code class="language-matlab">Ag = rgb2gray(A);

imshow(Ag)

</code></pre>

<p><img src="[../media/2017-12-04-17-47-57.png](https://tesar-tech.github.io/zodoc/docs/media/2017-12-04-17-47-57.png)" class="img-fluid" alt=""></p>

<h1 id="decompose-rgb-channels">Zobrazte jednotlivé barevné kanály</h1>

<pre><code class="language-matlab">R=A(:,:,1);

G=A(:,:,2);

B=A(:,:,3);

  

subplot 221;imshow(A);title('Original');

subplot 222;imshow(R);title('Cerveny');

subplot 223;imshow(G);title('Zeleny');

subplot 224;imshow(B);title('Modry');

</code></pre>

<p>Všimněte si tmavé barvy v modrém kanálu, která není součástí žluté barvy, narozdíl od červeného a zeleného kanálu.</p>

<p><img src="[../media/2017-12-04-17-59-08.png](https://tesar-tech.github.io/zodoc/docs/media/2017-12-04-17-59-08.png)" class="img-fluid" alt=""></p>

<h2 id="colorize-channels">Barvy kanálů</h2>

<p>Set non-color channels to zero</p>

<pre><code class="language-matlab">R1=A;G1=A;B1=A; %nakopírujeme originální obrázek do nových proměnných

  

R1(:,:,[2,3])=0;

G1(:,:,[1,3])=0;

B1(:,:,[1,2])=0;

  

subplot 221;imshow(A);title('Original');

subplot 222;imshow(R1);title('Cerveny kanal');

subplot 223;imshow(G1);title('Zeleny kanal');

subplot 224;imshow(B1);title('Modry kanal');

</code></pre>

<p><img src="[../media/colorizedChannels.png](https://tesar-tech.github.io/zodoc/docs/media/colorizedChannels.png)" class="img-fluid" alt=""></p>

<h1 id="negative-image">Negativ obrázku</h1>

<pre><code class="language-matlab">An=imcomplement(A);

%nebo

An= 255-A; %pokud obrázek splňuje třídu unit8

imshow(An)

</code></pre>

<p><img src="[../media/negative.png](https://tesar-tech.github.io/zodoc/docs/media/negative.png)" class="img-fluid" alt=""></p>

<h1 id="black-white">Černobílá</h1>

<pre><code class="language-matlab">Abw = imbinarize(Ag); %proměnná ze šedotónu

%BW = im2bw(A); % ve starších verzích matlabu

imshow(Abw)

  

</code></pre>

<p><img src="[../media/binarized.png](https://tesar-tech.github.io/zodoc/docs/media/binarized.png)" class="img-fluid" alt=""></p>

<h2 id="custom-way">Jiný způsob</h2>

<p>Výsledek z <code>Ag&lt;128</code> je binární matice - tzn.. černobílá</p>

<pre><code class="language-matlab">imshow(Ag&lt;128);

</code></pre>

<h1 id="bw-animation">Animovaný černobílý obrázek</h1>

<pre><code class="language-matlab">figure

ax = axes;% abychom přepsali původní figuru

THR=0;

for i=1:100

while (THR&lt;=255)

imshow(Ag&gt;THR,'Parent',ax)

THR=THR+10;

pause(0.05)

end

while (THR&gt;=0)

imshow(Ag&gt;THR,'Parent',ax)

THR=THR-10;

pause(0.05)

end

end

</code></pre>

<h2 id="save-animation-as-gif">Uložení animace jako gifu</h2>
<pre><code class="language-matlab">firstTime = 1;gifName = 'bw_anim.gif';
for ii = 1:5:256
    
   curr_img = (Ag&lt;ii)*255;%0 and 255 values
   [A,map] = gray2ind(curr_img,2); 
   
    if firstTime ==1%první snímek je uložen zvlášť
        imwrite(A,map,gifName,'gif','LoopCount',Inf,'DelayTime',0.001);
    firstTime = 0;
    else
        imwrite(A,map,gifName,'gif','WriteMode','append','DelayTime',0.001);
    end 
 end
 %pak zkontrolovat složku na disku, zde bude uložen gif
</code></pre>
<p><img src="../media/bw_anim.gif" class="img-fluid" alt=""></p>


<p><img src="[../media/bw_anim.gif](https://tesar-tech.github.io/zodoc/docs/media/bw_anim.gif)" class="img-fluid" alt=""></p>

<h1 id="indexove_zobrazeni">Indexové zobrazení</h1>

<pre><code class="language-matlab">
AInd=rgb2ind(A,7);
imshow(AInd); %jeden ze způsobů

[AInd,map]=rgb2ind(A,7);
imshow(AInd, map); %druhý způsob

<p><img src="[../media/kytka_index.jpg]" class="img-fluid" alt=""></p>

A2=ind2rgb(AInd, map)
imshow(A2); %vrácení do původního stavu, obrázek ale nebude již stejný


</code></pre>