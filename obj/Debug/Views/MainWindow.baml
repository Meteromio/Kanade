   M S B A M L   `   `   `  ����  MidnightRave    TootDon.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   P LPrism.Wpf, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � Title$ MidniteRave��5   	   $	��433��6   $	��599��6*    � UseLayoutRounding .  .��5      �� .+�5   
   �  � RowDefinitions 5	      �� 5
      $��40 �6    .+�5      �� -   5        $��認証��5      $
��Left=�5      $��25��5      $��5q�5      $��Center=�5      $��86��5      {�5      �� *AuthButonIsEnabled+5      � 5   
   $��5q�6    5      �� 5      $	��300 �6    .+�5      �� $
��Left=�6   $	��290��61   $	��Top=�6>   $	��569��6V   5      � 5   
   $��5q�6    � ColumnDefinitions 5      �� 5      $
��524* �6#   �� 5      $	��67* �6#    5       �� 5!      $��30 �6    .+�5#      �� $��2q�6    �� TextWrapping$
 Wrap=�5$      $��20��5&      $��Bottom=�5'      ��5%      �� *
TootText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5'      �� 5(      $��Label��6   $
��Left=�5)      $��14��5*      $��10,271,0,-240q�5+      $	��Top=�5,      $��60��5-      �� 5.      $
��Toot��6   $��2q�5/      $��Right=�50      $��55��51      $��25��52      $	��Top=�53       J� RenderTransformOrigin$ 0.564,-0.32&�54      $��1��55   ;   ��6   �� *TootButtonClicked+6;   56      57      58      