   M S B A M L   `   `   `  ����G  CDBDataToJson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DBDataToJsonDBDataToJson  5   	       DBDataToJson.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:DBDataToJson     5   	     � Title$  数据库数据转JSON��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��数据库：��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N   $��70��6f   $��25��6q   �� 5   
   -   5        $��txtDbString��5      $
��Left=�6%   $��22��6@   $��	88,10,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $$��配置数据库连接字符串��6s   $	��Top=�6�   $	��694��6�   �� 5   
   -   5        $��txtSqlString��5      $
��Left=�6&   $��45��6A   $��	10,48,0,0q�6M   $
 Wrap=�6`   $��需要执行的sql语句��6t   $	��Top=�6�   $	��772��6�   �� 5   
   -   5        $��txtJsonString��5      $
��Left=�6'   $	��263��6B   $��
10,147,0,0q�6O   $
 Wrap=�6c   $��Json显示区域��6w   $	��Top=�6�   $	��755��6�   �� 5   
   -   5        $��	btnSearch��5      $��确定��6"   $
��Left=�6/   $��
23,106,0,0q�6J   $	��Top=�6^   $��88��6v   $��22��6�   �� 5   
   -   5        $��btnCopy��5      $��复制��6    $
��Left=�6-   $��141,106,0,0q�6H   $	��Top=�6]   $��88��6u    J� RenderTransformOrigin$ 0.136,0.259&�6�   5      5      