   M S B A M L   `   `   `  ���� A  =MK1101, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MK1101MK1101      MK1101.Form01   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:MK1101     -     � Title$  
MainWindow��$
��1020��$
��1920��$��20(����	#FFF7B554.���  � RowDefinitions �� $	��100 ��� $��50 ��� �� $	��100 ��� $��0* �.+�A� $��2�� A� Columns$ 3��.+�A� $ 4��.+��� -    ��Name$ BtnF01��$��
F01:検索��$��24(�$y�Visible=����	#FF00FFF3�� -   $ BtnF02��$��F02:検索クリア��$��24(�$y�Visible=����	#FF00FFF3�� -   $ BtnF03��$��F03:詳細クリア��$��24(�$y�Visible=����	#FF00FFF3�� -   $ BtnF04��$
��F04:��$��24(�$y�Hidden=����	#FF00FFF3A� $ 4��.+��� -   $ BtnF05��$��
F05:保存��$��24(�$y�Visible=����	#FF00FFF3�� -   $ BtnF06��$
��F06:��$��24(�$y�Hidden=����	#FF00FFF3�� -   $ BtnF07��$
��F07:��$��24(�$y�Hidden=����	#FF00FFF3�� -	   $ BtnF08��$
��F08:��$��24(�$y�Hidden=����	#FF00FFF3A� $ 4��.+��� -
   $ BtnF09��$
��F09:��$��24(�$y�Hidden=����	#FF00FFF3�� -   $ BtnF10��$
��F10:��$��24(�$y�Hidden=����	#FF00FFF3�� -   $ BtnF11��$��F11:ヘルプ��$��24(�$y�Hidden=����	#FF00FFF3�� -   $ BtnF12��$��
F12:終了��$��24(�$y�Visible=����	#FF00FFF3� $��1��$��2��.+��� $$��資材マスタメンテ画面��$��Center=�$��24(��� $��エラーメッセージ��$��2��$��3��$��0,1,0,1q�
���   �.���� $��10,0,1,0q�$��37�� J� RenderTransformOrigin$ 0.5,0.5&����� *
AppMessage+z�V� .~��� ��  �� AngleX$ 2.936Q��� T�  T� X$ -0.949Q�� $��2��$��2��$��0,0,0,0q� � ColumnDefinitions �� $	��724 ��� .+�� $��2��$��2,2,2,2q����	#FFF7B554 �� $	��273 ��� .+��� $��検索条件��$��2,2,2,2q����	#FFF7B554$��24(�.���� .+��� $>��8資材コード(※末に[%]記載で前方一致検索)��$��3,1,3,1q�$��24(��� $��3,1,3,1q����� *SearchMaterialCode+�� $5��/品名(※末に[%]記載で前方一致検索)��$��3,1,3,1q�$��24(��� $��3,1,3,1q����� *SearchMaterialName+��  �� Orientation$  Horizontal =�.+��� $��無効含む��$��3,1,3,1q�$��24(��� $��3,1,3,1q�$��Center=�	 d� 	IsChecked	 �� *SearchInvalidFlg+z��� 
 �� ScaleX$	
 1.5Q� �� ScaleY$	 1.5Q�&   System.Windows.Controls.DataGrid  -   $��MaterialInfo��$��1��$��3,3,3,10q�   
IsReadOnly$
 True��   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   FrozenColumnCount$ 1��   AutoGenerateColumns$ False��   CanUserAddRows$ False������ *MaterialInfo+   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 削除��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *invalid_flg+   HeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value
 ��  ���  � ��
 �������  � ��$ 24(���  � ��$ Center=�   ElementStyle �� " ��.���  � ��$ 0,1,0,0q���  � ��$ Center=���  � ��$ Center=���  �@J�IsHitTestVisible$ False��0  *System.Windows.Controls.DataGridTextColumn  $ 資材コード��$	 250  �� *material_code+ �� "  .���  � ��
 ��  ���  � ��
 �������  � ��$ 24(���  � ��$ Center=�  $ 品名��$	 200  �� *material_name+ �� "  .���  � ��$ Center=�  $ 型名��$	 200  �� *	type_name+ �� "  .���  � ��$ Center=��� $��1��$��詳細��$��2��$��2,2,2,2q����	#FF00FF80$��24(�.��� .+��� $��0��$��2,2,2,2q�.+��� $  Horizontal =�.+��� $��無効��$��3,1,3,1q�$��24(��� $��3,1,3,1q�$��Center=�	 �� *
InvalidFlg+z��� $	
 1.5Q�$	 1.5Q��� $��資材コード��$��3,1,3,1q�$��24(��� $��3,1,3,1q����� *MaterialCode+�� $��品名��$��24(��� ���� *MaterialName+�� $��単位��$��24(��� $  Horizontal =�.+��� $	��400��$��50�� �� SelectedIndex �� *UnitKbnInfo_Selectedindex+���� *UnitKbnInfo+���� .R��� $ 
Horizontal=�.+��� $��80��$��Right=�$��Center=����� *kbn+�� $�� ： ��$��Center=��� $��Center=����� *name+�� $��型名��$��24(��� ���� *
TypeName+�� $��規格・仕様��$��24(��� ���� *KikakuShiyo+�� $��備考��$��24(��� $��76��. �/� .T�J� .*�.*��� ��� *Biko+