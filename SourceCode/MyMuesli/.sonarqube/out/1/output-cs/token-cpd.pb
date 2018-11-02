‹
iC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Model\CustomerDetails.cs
	namespace 	
MyMuesli
 
. 
Model 
{ 
public 

class 
CustomerDetails  
:! "
ICustomerDetails# 3
{ 
public 
string 
ID 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
City 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Zip 
{ 
get 
;  
set! $
;$ %
}& '
public		 
string		 
Country		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
string

 
Phone

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
} 
} –
kC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Service\DatabaseService.cs
	namespace 	
MyMuesli
 
. 
Service 
{ 
class 	
DatabaseService
 
: 
IDatabaseService ,
{ 
public		 
void		 
AddUser		 
(		 
ICustomerDetails		 ,
customer		- 5
)		5 6
{

 	
} 	
public  
ObservableCollection #
<# $
string$ *
>* +
GetCountries, 8
(8 9
)9 :
{ 	
return 
null 
; 
} 	
public  
ObservableCollection #
<# $
Cereal$ *
>* +
GetMyCereals, 8
(8 9
ICustomerDetails9 I
customerJ R
)R S
{ 	
return 
null 
; 
} 	
} 
} ¸
lC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Service\IDatabaseService.cs
	namespace		 	
MyMuesli		
 
.		 
Service		 
{

 
public 

	interface 
IDatabaseService %
{ 
void 
AddUser 
( 
ICustomerDetails %
customer& .
). /
;/ 0 
ObservableCollection 
< 
string #
># $
GetCountries% 1
(1 2
)2 3
;3 4 
ObservableCollection 
< 
Cereal #
># $
GetMyCereals% 1
(1 2
ICustomerDetails2 B
_customerDetailsC S
)S T
;T U
} 
} «
dC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\ViewModelLocator.cs
	namespace 	
MyMuesli
 
{ 
public 

class 
ViewModelLocator !
{ 
private 
readonly 
UnityContainer '
	container( 1
;1 2
public 
ViewModelLocator 
(  
)  !
{ 	
	container 
= 
new 
UnityContainer *
(* +
)+ ,
;, -
RegisterInstances 
( 
) 
;  
;I J
} 	
private 
void 
RegisterInstances &
(& '
)' (
{ 	
	container 
. 
RegisterType "
<" #
ICustomerDetails# 3
,3 4
CustomerDetails4 C
>C D
(D E
newE H.
"ContainerControlledLifetimeManagerI k
(k l
)l m
)m n
;n o
	container 
. 
RegisterType "
<" #
IDatabaseService# 3
,3 4
DatabaseService5 D
>D E
(E F
newF I.
"ContainerControlledLifetimeManagerJ l
(l m
)m n
)n o
;o p
} 	
public   
MainViewModel   
Main   !
=>  " $
	container  % .
.  . /
Resolve  / 6
<  6 7
MainViewModel  7 D
>  D E
(  E F
)  F G
;  G H
public!! 
OrderViewModel!! 
Order!! #
=>!!$ &
	container!!' 0
.!!0 1
Resolve!!1 8
<!!8 9
OrderViewModel!!9 G
>!!G H
(!!H I
)!!I J
;!!J K
public""  
CerealMixerViewModel"" #
Cereal""$ *
=>""+ -
	container"". 7
.""7 8
Resolve""8 ?
<""? @ 
CerealMixerViewModel""@ T
>""T U
(""U V
)""V W
;""W X
public## "
MyCerealMixesViewModel## %
MyCereal##& .
=>##/ 1
	container##2 ;
.##; <
Resolve##< C
<##C D"
MyCerealMixesViewModel##D Z
>##Z [
(##[ \
)##\ ]
;##] ^
public$$ $
CustomerDetailsViewModel$$ '
Customer$$( 0
=>$$1 3
	container$$4 =
.$$= >
Resolve$$> E
<$$E F$
CustomerDetailsViewModel$$F ^
>$$^ _
($$_ `
)$$` a
;$$a b
}%% 
}&& ¢
`C:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Model\Cereal.cs
	namespace 	
MyMuesli
 
. 
Model 
{ 
public 

class 
Cereal 
{ 
} 
} Æ
rC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\ViewModel\CerealMixerViewModel.cs
	namespace 	
MyMuesli
 
. 
	ViewModel 
{ 
public		 

class		  
CerealMixerViewModel		 %
{

 
} 
} Â1
vC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\ViewModel\CustomerDetailsViewModel.cs
	namespace 	
MyMuesli
 
. 
	ViewModel 
{		 
public

 

class

 $
CustomerDetailsViewModel

 )
:

) *
ViewModelBase

+ 8
{ 
private 
IDatabaseService  
_databaseService! 1
;1 2
private 
ICustomerDetails  
_customerDetails! 1
;1 2
public $
CustomerDetailsViewModel '
(' (
IDatabaseService( 8
service9 @
,@ A
ICustomerDetailsB R
customerS [
)[ \
{ 	
_databaseService 
= 
service &
;& '
_customerDetails 
= 
customer '
;' (
	Countries 
= 
GetCountries $
($ %
)% &
;& '
SaveCommand 
= 
new 
RelayCommand *
(* +
SaveUser+ 3
)3 4
;4 5
MenuCommand 
= 
new 
RelayCommand *
(* +

BackToMenu+ 5
)5 6
;6 7
} 	
private  
ObservableCollection $
<$ %
string% +
>+ ,
GetCountries- 9
(9 :
): ;
{ 	
return 
_databaseService #
.# $
GetCountries$ 0
(0 1
)1 2
;2 3
} 	
private 
void 

BackToMenu 
(  
)  !
{   	
}!! 	
private## 
void## 
SaveUser## 
(## 
)## 
{$$ 	
_databaseService%% 
.%% 
AddUser%% $
(%%$ %
_customerDetails%%% 5
)%%5 6
;%%6 7
}&& 	
public(( 
ICommand(( 
SaveCommand(( #
{(($ %
get((& )
;(() *
set((+ .
;((. /
}((0 1
public)) 
ICommand)) 
MenuCommand)) #
{))$ %
get))& )
;))) *
set))+ .
;)). /
}))0 1
public++ 
string++ 
Name++ 
{,, 	
get-- 
{-- 
return-- 
_customerDetails-- )
.--) *
Name--* .
;--. /
}--/ 0
set.. 
{// 
_customerDetails00  
.00  !
Name00! %
=00& '
value00( -
;00- . 
RaisePropertyChanged11 $
(11$ %
)11% &
;11& '
}22 
}33 	
public44 
string44 
Address44 
{44 
get55 
{55 
return55 
_customerDetails55 )
.55) *
Name55* .
;55. /
}550 1
set66 
{77 
_customerDetails88  
.88  !
Name88! %
=88& '
value88( -
;88- . 
RaisePropertyChanged99 $
(99$ %
)99% &
;99& '
}:: 
};; 	
public<< 
string<< 
Zip<< 
{<< 
get== 
{== 
return== 
_customerDetails== )
.==) *
Zip==* -
;==- .
}==/ 0
set>> 
{?? 
_customerDetails@@  
.@@  !
Zip@@! $
=@@% &
value@@' ,
;@@, - 
RaisePropertyChangedAA $
(AA$ %
)AA% &
;AA& '
}BB 
}CC 	
publicDD 
stringDD 
CityDD 
{DD 
getEE 
{EE 
returnEE 
_customerDetailsEE )
.EE) *
CityEE* .
;EE. /
}EE0 1
setFF 
{GG 
_customerDetailsHH  
.HH  !
CityHH! %
=HH& '
valueHH( -
;HH- . 
RaisePropertyChangedII $
(II$ %
)II% &
;II& '
}JJ 
}KK 	
publicLL 
stringLL 
SelectedCountryLL %
{LL& '
getMM 
{MM 
returnMM 
_customerDetailsMM )
.MM) *
CountryMM* 1
;MM1 2
}MM3 4
setNN 
{OO 
_customerDetailsPP  
.PP  !
CountryPP! (
=PP) *
valuePP+ 0
;PP0 1 
RaisePropertyChangedQQ $
(QQ$ %
)QQ% &
;QQ& '
}RR 
}SS 	
privateUU  
ObservableCollectionUU $
<UU$ %
stringUU% +
>UU+ ,

_countriesUU- 7
;UU7 8
publicVV  
ObservableCollectionVV #
<VV# $
stringVV$ *
>VV* +
	CountriesVV, 5
{VV6 7
getWW 
{XX 
returnYY 

_countriesYY !
;YY! "
}ZZ 
set[[ 
{\\ 

_countries]] 
=]] 
value]] "
;]]" # 
RaisePropertyChanged^^ $
(^^$ %
)^^% &
;^^& '
}__ 
}`` 	
publicbb 
stringbb 
Phonebb 
{cc 	
getdd 
{dd 
returndd 
_customerDetailsdd )
.dd) *
Phonedd* /
;dd/ 0
}dd1 2
setee 
{ff 
_customerDetailsgg  
.gg  !
Phonegg! &
=gg' (
valuegg) .
;gg. / 
RaisePropertyChangedhh $
(hh$ %
)hh% &
;hh& '
}ii 
}jj 	
publicll 
stringll 
Emailll 
{ll 
getmm 
{mm 
returnmm 
_customerDetailsmm )
.mm) *
Emailmm* /
;mm/ 0
}mm1 2
setnn 
{oo 
_customerDetailspp  
.pp  !
Emailpp! &
=pp' (
valuepp) .
;pp. / 
RaisePropertyChangedqq $
(qq$ %
)qq% &
;qq& '
}rr 
}ss 	
}tt 
}uu Ö
jC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Model\ICustomerDetails.cs
	namespace 	
MyMuesli
 
. 
Model 
{ 
public 

	interface 
ICustomerDetails %
{ 
string 
Name 
{ 
get 
; 
set 
; 
}  !
string 
City 
{ 
get 
; 
set 
; 
}  !
string 
Zip 
{ 
get 
; 
set 
; 
}  
string 
Country 
{ 
get 
; 
set !
;! "
}# $
string		 
Phone		 
{		 
get		 
;		 
set		 
;		  
}		! "
string

 
Email

 
{

 
get

 
;

 
set

 
;

  
}

! "
} 
} ²
kC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\ViewModel\MainViewModel.cs
	namespace 	
MyMuesli
 
. 
	ViewModel 
{ 
public		 

class		 
MainViewModel		 
:		 
ViewModelBase		  -
{

 
public 
MainViewModel 
( 
) 
{ 	
ExitCommand 
= 
new 
RelayCommand *
(* +
(+ ,
), -
=>- /
Environment0 ;
.; <
Exit< @
(@ A
$numA B
)B C
)C D
;D E"
CustomerDetailsCommand "
=# $
new% (
RelayCommand) 5
(5 6
OpenCustomerDetails6 I
)I J
;J K
CerealMixerCommand 
=  
new! $
RelayCommand% 1
(1 2
OpenCerealMixer2 A
)A B
;B C
MyCerealCommand 
= 
new !
RelayCommand" .
(. /
OpenMyCereals/ <
)< =
;= >
OrderCommand 
= 
new 
RelayCommand +
(+ ,

OpenOrders, 6
)6 7
;7 8
} 	
private 
void 

OpenOrders 
(  
)  !
{ 	
	OrderView 
	orderView 
=  !
new" %
	OrderView& /
(/ 0
)0 1
;1 2
	orderView 
. 
Show 
( 
) 
; 
} 	
private 
void 
OpenMyCereals "
(" #
)# $
{ 	
MyCerealMixesView 
	orderView '
=( )
new* -
MyCerealMixesView. ?
(? @
)@ A
;A B
	orderView 
. 
Show 
( 
) 
; 
} 	
private   
void   
OpenCerealMixer   $
(  $ %
)  % &
{!! 	
CerealMixerView"" 
	orderView"" %
=""& '
new""( +
CerealMixerView"", ;
(""; <
)""< =
;""= >
	orderView## 
.## 
Show## 
(## 
)## 
;## 
}$$ 	
private&& 
void&& 
OpenCustomerDetails&& (
(&&( )
)&&) *
{'' 	
CustomerDetailsView(( 
	orderView((  )
=((* +
new((, /
CustomerDetailsView((0 C
(((C D
)((D E
;((E F
	orderView)) 
.)) 
Show)) 
()) 
))) 
;)) 
}** 	
public,, 
ICommand,, 
ExitCommand,, #
{,,$ %
get,,& )
;,,) *
set,,+ .
;,,. /
},,0 1
public-- 
ICommand-- "
CustomerDetailsCommand-- .
{--/ 0
get--1 4
;--4 5
set--6 9
;--9 :
}--; <
public.. 
ICommand.. 
CerealMixerCommand.. *
{..+ ,
get..- 0
;..0 1
set..2 5
;..5 6
}..7 8
public// 
ICommand// 
MyCerealCommand// '
{//( )
get//* -
;//- .
set/// 2
;//2 3
}//4 5
public00 
ICommand00 
OrderCommand00 $
{00% &
get00' *
;00* +
set00, /
;00/ 0
}001 2
}11 
}22 £
tC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\ViewModel\MyCerealMixesViewModel.cs
	namespace 	
MyMuesli
 
. 
	ViewModel 
{ 
public 

class "
MyCerealMixesViewModel '
{ 
private 
ICustomerDetails  
_customerDetails! 1
;1 2
private 
IDatabaseService  
_databaseService! 1
;1 2
public "
MyCerealMixesViewModel %
(% &
IDatabaseService& 6
databaseService7 F
,F G
ICustomerDetailsG W
customerX `
)` a
{ 	
_customerDetails 
= 
customer '
;' (
_databaseService 
= 
databaseService .
;. /
	MyCereals 
= 
_databaseService (
.( )
GetMyCereals) 5
(5 6
_customerDetails6 F
)F G
;G H
} 	
public 
ICommand 
EditCommand #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
ICommand 
DeleteCommand %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
ICommand 
MenuCommand #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
Cereal 
SelectedCereal $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public  
ObservableCollection #
<# $
Cereal$ *
>* +
	MyCereals, 5
{6 7
get8 ;
;; <
}= >
}   
}!! á
lC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\ViewModel\OrderViewModel.cs
	namespace 	
MyMuesli
 
. 
	ViewModel 
{ 
public 

class 
OrderViewModel 
{ 
public 
OrderViewModel 
( 
) 
{ 	
SaveCommand 
= 
new 
RelayCommand *
(* +
Save+ /
)/ 0
;0 1
MenuCommand 
= 
new 
RelayCommand *
(* +

BackToMenu+ 5
)5 6
;6 7
} 	
private 
void 

BackToMenu 
(  
)  !
{ 	
} 	
private 
void 
Save 
( 
) 
{ 	
} 	
public 
string 
MuesliMixesValues '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public   
string   
ShippingPrice   #
{  $ %
get  & )
;  ) *
set  + .
;  . /
}  0 1
public!! 
string!! 

TaxesValue!!  
{!!! "
get!!# &
;!!& '
set!!( +
;!!+ ,
}!!- .
public"" 
string"" 

GrandTotal""  
{""! "
get""# &
;""& '
set""( +
;""+ ,
}""- .
public$$  
ObservableCollection$$ #
<$$# $
Cereal$$$ *
>$$* +
	MyCereals$$, 5
{$$6 7
get$$8 ;
;$$; <
set$$= @
;$$@ A
}$$B C
public&& 
ICommand&& 
SaveCommand&& #
{&&$ %
get&&& )
;&&) *
set&&+ .
;&&. /
}&&0 1
public'' 
ICommand'' 
MenuCommand'' #
{''$ %
get''& )
;'') *
set''+ .
;''. /
}''0 1
}(( 
})) ¬
nC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Views\CerealMixerView.xaml.cs
	namespace 	
MyMuesli
 
. 
Views 
{ 
public 

partial 
class 
CerealMixerView (
:) *
Window+ 1
{ 
public 
CerealMixerView 
( 
)  
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} ¸
rC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Views\CustomerDetailsView.xaml.cs
	namespace 	
MyMuesli
 
. 
Views 
{ 
public 

partial 
class 
CustomerDetailsView ,
:- .
Window/ 5
{ 
public 
CustomerDetailsView "
(" #
)# $
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} ²
pC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Views\MyCerealMixesView.xaml.cs
	namespace 	
MyMuesli
 
. 
Views 
{ 
public 

partial 
class 
MyCerealMixesView *
:+ ,
Window- 3
{ 
public 
MyCerealMixesView  
(  !
)! "
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} š
hC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Views\OrderView.xaml.cs
	namespace 	
MyMuesli
 
. 
Views 
{ 
public 

partial 
class 
	OrderView "
:# $
Window% +
{ 
public 
	OrderView 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} ¶
\C:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\App.xaml.cs
	namespace		 	
MyMuesli		
 
{

 
public 

partial 
class 
App 
: 
Application *
{ 
} 
} õ
cC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\MainWindow.xaml.cs
	namespace 	
MyMuesli
 
{ 
public 

partial 
class 

MainWindow #
:$ %
Window& ,
{ 
public 

MainWindow 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "
} 	
} 
} ²
kC:\Arbeitsordner\_ImportantStuff\IPA\Probe\MyMuesli\SourceCode\MyMuesli\MyMuesli\Properties\AssemblyInfo.cs
[

 
assembly

 	
:

	 

AssemblyTitle

 
(

 
$str

 #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyDescription 
( 
$str !
)! "
]" #
[ 
assembly 	
:	 
!
AssemblyConfiguration  
(  !
$str! #
)# $
]$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str *
)* +
]+ ,
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str %
)% &
]& '
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str =
)= >
]> ?
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
["" 
assembly"" 	
:""	 

	ThemeInfo"" 
("" &
ResourceDictionaryLocation## 
.## 
None## #
,### $&
ResourceDictionaryLocation&& 
.&& 
SourceAssembly&& -
))) 
])) 
[66 
assembly66 	
:66	 

AssemblyVersion66 
(66 
$str66 $
)66$ %
]66% &
[77 
assembly77 	
:77	 

AssemblyFileVersion77 
(77 
$str77 (
)77( )
]77) *