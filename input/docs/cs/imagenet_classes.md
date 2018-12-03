title: Zobrazení 1000 tříd databáze ImageNet pomocí konvoluční neuronové sítě Alexnet
Description: Jednoduché zobrazení 1000 klasifikačních tříd z obrázkové databáze ImageNet v proměnné pro snadné vyhledávání jednotlivých tříd v abecedně seřazeném seznamu.
---
```matlab
net = alexnet; % načíst sít
ClassNames = net.Layers(end).ClassNames; %uložit všechny názvy tříd do proměnné
ClassNamesSorted = sort(ClassNames); % třídit názvy sítí podle abecedy
ClassIndexes = string(num2cell(1:1000)'); % vytvořit indexování pro zobrazení podle abecedy
str=strcat((ClassNamesSorted)); % seřadit názvy horizontálně
result = strcat(ClassIndexes,repmat(":",1000, 1),str); % přiřadit do proměnné názvy tříd a očíslovat je

disp(result) %Zobrazit výsledky
```
#Výsledky 
1:Afghan hound
2:African chameleon
3:African crocodile
4:African elephant
5:African grey
6:African hunting dog
7:Airedale
8:American Staffordshire terrier
9:American alligator
10:American black bear
11:American chameleon
12:American coot
13:American egret
14:American lobster
15:Angora
16:Appenzeller
17:Arabian camel
18:Arctic fox
19:Australian terrier
20:Band Aid
21:Bedlington terrier
22:Bernese mountain dog
23:Blenheim spaniel
24:Border collie
25:Border terrier
26:Boston bull
27:Bouvier des Flandres
28:Brabancon griffon
29:Brittany spaniel
30:CD player
31:Cardigan
32:Chesapeake Bay retriever
33:Chihuahua
34:Christmas stocking
35:Crock Pot
36:Dandie Dinmont
37:Doberman
38:Dungeness crab
39:Dutch oven
40:Egyptian cat
41:English foxhound
42:English setter
43:English springer
44:EntleBucher
45:Eskimo dog
46:European fire salamander
47:European gallinule
48:French bulldog
49:French horn
50:French loaf
51:German shepherd
52:German short-haired pointer
53:Gila monster
54:Gordon setter
55:Granny Smith
56:Great Dane
57:Great Pyrenees
58:Greater Swiss Mountain dog
59:Ibizan hound
60:Indian cobra
61:Indian elephant
62:Irish setter
63:Irish terrier
64:Irish water spaniel
65:Irish wolfhound
66:Italian greyhound
67:Japanese spaniel
68:Kerry blue terrier
69:Komodo dragon
70:Labrador retriever
71:Lakeland terrier
72:Leonberg
73:Lhasa
74:Loafer
75:Madagascar cat
76:Maltese dog
77:Mexican hairless
78:Model T
79:Newfoundland
80:Norfolk terrier
81:Norwegian elkhound
82:Norwich terrier
83:Old English sheepdog
84:Pekinese
85:Pembroke
86:Persian cat
87:Petri dish
88:Polaroid camera
89:Pomeranian
90:Rhodesian ridgeback
91:Rottweiler
92:Saint Bernard
93:Saluki
94:Samoyed
95:Scotch terrier
96:Scottish deerhound
97:Sealyham terrier
98:Shetland sheepdog
99:Shih-Tzu
100:Siamese cat
101:Siberian husky
102:Staffordshire bullterrier
103:Sussex spaniel
104:Tibetan mastiff
105:Tibetan terrier
106:Walker hound
107:Weimaraner
108:Welsh springer spaniel
109:West Highland white terrier
110:Windsor tie
111:Yorkshire terrier
112:abacus
113:abaya
114:academic gown
115:accordion
116:acorn
117:acorn squash
118:acoustic guitar
119:admiral
120:affenpinscher
121:agama
122:agaric
123:aircraft carrier
124:airliner
125:airship
126:albatross
127:alligator lizard
128:alp
129:altar
130:ambulance
131:amphibian
132:analog clock
133:anemone fish
134:ant
135:apiary
136:apron
137:armadillo
138:artichoke
139:ashcan
140:assault rifle
141:axolotl
142:baboon
143:backpack
144:badger
145:bagel
146:bakery
147:balance beam
148:bald eagle
149:balloon
150:ballplayer
151:ballpoint
152:banana
153:banded gecko
154:banjo
155:bannister
156:barbell
157:barber chair
158:barbershop
159:barn
160:barn spider
161:barometer
162:barracouta
163:barrel
164:barrow
165:baseball
166:basenji
167:basketball
168:basset
169:bassinet
170:bassoon
171:bath towel
172:bathing cap
173:bathtub
174:beach wagon
175:beacon
176:beagle
177:beaker
178:bearskin
179:beaver
180:bee
181:bee eater
182:beer bottle
183:beer glass
184:bell cote
185:bell pepper
186:bib
187:bicycle-built-for-two
188:bighorn
189:bikini
190:binder
191:binoculars
192:birdhouse
193:bison
194:bittern
195:black and gold garden spider
196:black grouse
197:black stork
198:black swan
199:black widow
200:black-and-tan coonhound
201:black-footed ferret
202:bloodhound
203:bluetick
204:boa constrictor
205:boathouse
206:bobsled
207:bolete
208:bolo tie
209:bonnet
210:book jacket
211:bookcase
212:bookshop
213:borzoi
214:bottlecap
215:bow
216:bow tie
217:box turtle
218:boxer
219:brain coral
220:brambling
221:brass
222:brassiere
223:breakwater
224:breastplate
225:briard
226:broccoli
227:broom
228:brown bear
229:bubble
230:bucket
231:buckeye
232:buckle
233:bulbul
234:bull mastiff
235:bullet train
236:bulletproof vest
237:bullfrog
238:burrito
239:bustard
240:butcher shop
241:butternut squash
242:cab
243:cabbage butterfly
244:cairn
245:caldron
246:can opener
247:candle
248:cannon
249:canoe
250:capuchin
251:car mirror
252:car wheel
253:carbonara
254:cardigan
255:cardoon
256:carousel
257:carpenter's kit
258:carton
259:cash machine
260:cassette
261:cassette player
262:castle
263:catamaran
264:cauliflower
265:cello
266:cellular telephone
267:centipede
268:chain
269:chain mail
270:chain saw
271:chainlink fence
272:chambered nautilus
273:cheeseburger
274:cheetah
275:chest
276:chickadee
277:chiffonier
278:chime
279:chimpanzee
280:china cabinet
281:chiton
282:chocolate sauce
283:chow
284:church
285:cicada
286:cinema
287:cleaver
288:cliff
289:cliff dwelling
290:cloak
291:clog
292:clumber
293:cock
294:cocker spaniel
295:cockroach
296:cocktail shaker
297:coffee mug
298:coffeepot
299:coho
300:coil
301:collie
302:colobus
303:combination lock
304:comic book
305:common iguana
306:common newt
307:computer keyboard
308:conch
309:confectionery
310:consomme
311:container ship
312:convertible
313:coral fungus
314:coral reef
315:corkscrew
316:corn
317:cornet
318:coucal
319:cougar
320:cowboy boot
321:cowboy hat
322:coyote
323:cradle
324:crane
325:crane (machine)
326:crash helmet
327:crate
328:crayfish
329:crib
330:cricket
331:croquet ball
332:crossword puzzle
333:crutch
334:cucumber
335:cuirass
336:cup
337:curly-coated retriever
338:custard apple
339:daisy
340:dalmatian
341:dam
342:damselfly
343:desk
344:desktop computer
345:dhole
346:dial telephone
347:diamondback
348:diaper
349:digital clock
350:digital watch
351:dingo
352:dining table
353:dishrag
354:dishwasher
355:disk brake
356:dock
357:dogsled
358:dome
359:doormat
360:dough
361:dowitcher
362:dragonfly
363:drake
364:drilling platform
365:drum
366:drumstick
367:dugong
368:dumbbell
369:dung beetle
370:ear
371:earthstar
372:echidna
373:eel
374:eft
375:eggnog
376:electric fan
377:electric guitar
378:electric locomotive
379:electric ray
380:entertainment center
381:envelope
382:espresso
383:espresso maker
384:face powder
385:feather boa
386:fiddler crab
387:fig
388:file
389:fire engine
390:fire screen
391:fireboat
392:flagpole
393:flamingo
394:flat-coated retriever
395:flatworm
396:flute
397:fly
398:folding chair
399:football helmet
400:forklift
401:fountain
402:fountain pen
403:four-poster
404:fox squirrel
405:freight car
406:frilled lizard
407:frying pan
408:fur coat
409:gar
410:garbage truck
411:garden spider
412:garter snake
413:gas pump
414:gasmask
415:gazelle
416:geyser
417:giant panda
418:giant schnauzer
419:gibbon
420:go-kart
421:goblet
422:golden retriever
423:goldfinch
424:goldfish
425:golf ball
426:golfcart
427:gondola
428:gong
429:goose
430:gorilla
431:gown
432:grand piano
433:grasshopper
434:great grey owl
435:great white shark
436:green lizard
437:green mamba
438:green snake
439:greenhouse
440:grey fox
441:grey whale
442:grille
443:grocery store
444:groenendael
445:groom
446:ground beetle
447:guacamole
448:guenon
449:guillotine
450:guinea pig
451:gyromitra
452:hair slide
453:hair spray
454:half track
455:hammer
456:hammerhead
457:hamper
458:hamster
459:hand blower
460:hand-held computer
461:handkerchief
462:hard disc
463:hare
464:harmonica
465:harp
466:hartebeest
467:harvester
468:harvestman
469:hatchet
470:hay
471:head cabbage
472:hen
473:hen-of-the-woods
474:hermit crab
475:hip
476:hippopotamus
477:hog
478:hognose snake
479:holster
480:home theater
481:honeycomb
482:hook
483:hoopskirt
484:horizontal bar
485:hornbill
486:horned viper
487:horse cart
488:hot pot
489:hotdog
490:hourglass
491:house finch
492:howler monkey
493:hummingbird
494:hyena
495:iPod
496:ibex
497:ice bear
498:ice cream
499:ice lolly
500:impala
501:indigo bunting
502:indri
503:iron
504:isopod
505:jacamar
506:jack-o'-lantern
507:jackfruit
508:jaguar
509:jay
510:jean
511:jeep
512:jellyfish
513:jersey
514:jigsaw puzzle
515:jinrikisha
516:joystick
517:junco
518:keeshond
519:kelpie
520:killer whale
521:kimono
522:king crab
523:king penguin
524:king snake
525:kit fox
526:kite
527:knee pad
528:knot
529:koala
530:komondor
531:kuvasz
532:lab coat
533:lacewing
534:ladle
535:ladybug
536:lakeside
537:lampshade
538:langur
539:laptop
540:lawn mower
541:leaf beetle
542:leafhopper
543:leatherback turtle
544:lemon
545:lens cap
546:leopard
547:lesser panda
548:letter opener
549:library
550:lifeboat
551:lighter
552:limousine
553:limpkin
554:liner
555:lion
556:lionfish
557:lipstick
558:little blue heron
559:llama
560:loggerhead
561:long-horned beetle
562:lorikeet
563:lotion
564:loudspeaker
565:loupe
566:lumbermill
567:lycaenid
568:lynx
569:macaque
570:macaw
571:magnetic compass
572:magpie
573:mailbag
574:mailbox
575:maillot
576:maillot, tank suit
577:malamute
578:malinois
579:manhole cover
580:mantis
581:maraca
582:marimba
583:marmoset
584:marmot
585:mashed potato
586:mask
587:matchstick
588:maypole
589:maze
590:measuring cup
591:meat loaf
592:medicine chest
593:meerkat
594:megalith
595:menu
596:microphone
597:microwave
598:military uniform
599:milk can
600:miniature pinscher
601:miniature poodle
602:miniature schnauzer
603:minibus
604:miniskirt
605:minivan
606:mink
607:missile
608:mitten
609:mixing bowl
610:mobile home
611:modem
612:monarch
613:monastery
614:mongoose
615:monitor
616:moped
617:mortar
618:mortarboard
619:mosque
620:mosquito net
621:motor scooter
622:mountain bike
623:mountain tent
624:mouse
625:mousetrap
626:moving van
627:mud turtle
628:mushroom
629:muzzle
630:nail
631:neck brace
632:necklace
633:nematode
634:night snake
635:nipple
636:notebook
637:obelisk
638:oboe
639:ocarina
640:odometer
641:oil filter
642:orange
643:orangutan
644:organ
645:oscilloscope
646:ostrich
647:otter
648:otterhound
649:overskirt
650:ox
651:oxcart
652:oxygen mask
653:oystercatcher
654:packet
655:paddle
656:paddlewheel
657:padlock
658:paintbrush
659:pajama
660:palace
661:panpipe
662:paper towel
663:papillon
664:parachute
665:parallel bars
666:park bench
667:parking meter
668:partridge
669:passenger car
670:patas
671:patio
672:pay-phone
673:peacock
674:pedestal
675:pelican
676:pencil box
677:pencil sharpener
678:perfume
679:photocopier
680:pick
681:pickelhaube
682:picket fence
683:pickup
684:pier
685:piggy bank
686:pill bottle
687:pillow
688:pineapple
689:ping-pong ball
690:pinwheel
691:pirate
692:pitcher
693:pizza
694:plane
695:planetarium
696:plastic bag
697:plate
698:plate rack
699:platypus
700:plow
701:plunger
702:pole
703:polecat
704:police van
705:pomegranate
706:poncho
707:pool table
708:pop bottle
709:porcupine
710:pot
711:potpie
712:potter's wheel
713:power drill
714:prairie chicken
715:prayer rug
716:pretzel
717:printer
718:prison
719:proboscis monkey
720:projectile
721:projector
722:promontory
723:ptarmigan
724:puck
725:puffer
726:pug
727:punching bag
728:purse
729:quail
730:quill
731:quilt
732:racer
733:racket
734:radiator
735:radio
736:radio telescope
737:rain barrel
738:ram
739:rapeseed
740:recreational vehicle
741:red fox
742:red wine
743:red wolf
744:red-backed sandpiper
745:red-breasted merganser
746:redbone
747:redshank
748:reel
749:reflex camera
750:refrigerator
751:remote control
752:restaurant
753:revolver
754:rhinoceros beetle
755:rifle
756:ringlet
757:ringneck snake
758:robin
759:rock beauty
760:rock crab
761:rock python
762:rocking chair
763:rotisserie
764:rubber eraser
765:ruddy turnstone
766:ruffed grouse
767:rugby ball
768:rule
769:running shoe
770:safe
771:safety pin
772:saltshaker
773:sandal
774:sandbar
775:sarong
776:sax
777:scabbard
778:scale
779:schipperke
780:school bus
781:schooner
782:scoreboard
783:scorpion
784:screen
785:screw
786:screwdriver
787:scuba diver
788:sea anemone
789:sea cucumber
790:sea lion
791:sea slug
792:sea snake
793:sea urchin
794:seashore
795:seat belt
796:sewing machine
797:shield
798:shoe shop
799:shoji
800:shopping basket
801:shopping cart
802:shovel
803:shower cap
804:shower curtain
805:siamang
806:sidewinder
807:silky terrier
808:ski
809:ski mask
810:skunk
811:sleeping bag
812:slide rule
813:sliding door
814:slot
815:sloth bear
816:slug
817:snail
818:snorkel
819:snow leopard
820:snowmobile
821:snowplow
822:soap dispenser
823:soccer ball
824:sock
825:soft-coated wheaten terrier
826:solar dish
827:sombrero
828:sorrel
829:soup bowl
830:space bar
831:space heater
832:space shuttle
833:spaghetti squash
834:spatula
835:speedboat
836:spider monkey
837:spider web
838:spindle
839:spiny lobster
840:spoonbill
841:sports car
842:spotlight
843:spotted salamander
844:squirrel monkey
845:stage
846:standard poodle
847:standard schnauzer
848:starfish
849:steam locomotive
850:steel arch bridge
851:steel drum
852:stethoscope
853:stingray
854:stinkhorn
855:stole
856:stone wall
857:stopwatch
858:stove
859:strainer
860:strawberry
861:street sign
862:streetcar
863:stretcher
864:studio couch
865:stupa
866:sturgeon
867:submarine
868:suit
869:sulphur butterfly
870:sulphur-crested cockatoo
871:sundial
872:sunglass
873:sunglasses
874:sunscreen
875:suspension bridge
876:swab
877:sweatshirt
878:swimming trunks
879:swing
880:switch
881:syringe
882:tabby
883:table lamp
884:tailed frog
885:tank
886:tape player
887:tarantula
888:teapot
889:teddy
890:television
891:tench
892:tennis ball
893:terrapin
894:thatch
895:theater curtain
896:thimble
897:three-toed sloth
898:thresher
899:throne
900:thunder snake
901:tick
902:tiger
903:tiger beetle
904:tiger cat
905:tiger shark
906:tile roof
907:timber wolf
908:titi
909:toaster
910:tobacco shop
911:toilet seat
912:toilet tissue
913:torch
914:totem pole
915:toucan
916:tow truck
917:toy poodle
918:toy terrier
919:toyshop
920:tractor
921:traffic light
922:trailer truck
923:tray
924:tree frog
925:trench coat
926:triceratops
927:tricycle
928:trifle
929:trilobite
930:trimaran
931:tripod
932:triumphal arch
933:trolleybus
934:trombone
935:tub
936:turnstile
937:tusker
938:typewriter keyboard
939:umbrella
940:unicycle
941:upright
942:vacuum
943:valley
944:vase
945:vault
946:velvet
947:vending machine
948:vestment
949:viaduct
950:vine snake
951:violin
952:vizsla
953:volcano
954:volleyball
955:vulture
956:waffle iron
957:walking stick
958:wall clock
959:wallaby
960:wallet
961:wardrobe
962:warplane
963:warthog
964:washbasin
965:washer
966:water bottle
967:water buffalo
968:water jug
969:water ouzel
970:water snake
971:water tower
972:weasel
973:web site
974:weevil
975:whippet
976:whiptail
977:whiskey jug
978:whistle
979:white stork
980:white wolf
981:wig
982:wild boar
983:window screen
984:window shade
985:wine bottle
986:wing
987:wire-haired fox terrier
988:wok
989:wolf spider
990:wombat
991:wood rabbit
992:wooden spoon
993:wool
994:worm fence
995:wreck
996:yawl
997:yellow lady's slipper
998:yurt
999:zebra
1000:zucchini