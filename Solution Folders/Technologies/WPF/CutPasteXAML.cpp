//********************************************  
// Define a style for a btn in XAML 
//********************************************
<Window.Resources>
   <!--Push Me button style (named style)-->
   <Style x:Key="BtnPushMeStyle1">
      <Setter Property="TextElement.FontSize" Value="20" />
      <Setter Property="TextElement.FontWeight" Value="Bold" />
      <Setter Property="TextElement.Foreground" Value="Blue" />
   </Style>
   <!--This style applied to all btns (no key) and can be overridden by a named style-->
   <Style TargetType="{x:Type Button}">
         <Setter Property="FontSize" Value="12" />
         <Setter Property="FontWeight" Value="Thin" />
         <Setter Property="Foreground" Value="Yellow" />
   </Style>   
   <!--This implicit style is applied to all TextBlocks (no key) and can be overridden by a named style-->
   <Style TargetType="{x:Type TextBlock}">
        <Setter Property="FontSize" Value="32" />
        <Setter Property="FontWeight" Value="Thin" />
        <Setter Property="Foreground" Value="White" />
        <Setter Property="HorizontalAlignment" Value="Center" />
   </Style>
   <!--Explicit Style-->
   <Style x : Key = "PromptSyle" TargetType = "TextBlock">
	  <Setter Property = "FontSize" Value = "24" / >
      <Setter Property = "Margin" Value = "5" / >
      <Setter Property = "FontWeight" Value = "Bold" / >
   </Style>
</Window.Resources>

// Style statically assigned in xaml page
<TextBlock Text = "Last Name: " Grid.Row = "1" Grid.Column = "0" Style = "{StaticResource PromptSyle}" / >

// Change style of a btn in the code (Overrides the xml declaration). Dynamically assigned.
private void btnPushMe_Click(object sender, RoutedEventArgs e)
{
   btnPushMe.Style = (Style)FindResource("BtnPushMeStyle2");
}

//********************************************	
// DockPanel example
//********************************************
<DockPanel LastChildFill = "True">
	<Button Content = "Dock=Left" / >
	<Button Content = "Dock=Left" / >			// The dock panel layout supports multiple elements on one side.
	<Button Content = "Dock=Top" DockPanel.Dock = "Top" / >
	<Button Content = "Dock=Bottom" DockPanel.Dock = "Bottom" / >
	<Button Content = "Dock=Right" DockPanel.Dock = "Right" / > 
	<Button Content = "LastChildFill=True" / > // To dock an element to center of the panel it must be the last child of the panel and LastChildFill must be set true.
< / DockPanel>

//********************************************	
// TabControl example
//********************************************
<Grid>
	<TabControl>
		<TabItem Header = "Tab 1">This tab One< / TabItem>
		<TabItem Header = "Tab 2">
			<StackPanel>
				<StackPanel Orientation = "Horizontal">
					<TextBlock Text = "Name" / >
					<TextBox Width = "80"
						Height = "30"
						Margin = "10,0,0,0" / >
				< /StackPanel>
			< /StackPanel>
		< /TabItem>
	<TabItem Header = "Tab 3">< / TabItem>
< /TabControl>
< /Grid>
//********************************************	
// TreeView example
//********************************************
<Grid>
	<TreeView>
		<TreeViewItem Header = "Animals">
			<TreeViewItem Header = "Snail">< / TreeViewItem>
			<TreeViewItem Header = "Fish">< / TreeViewItem>
			<TreeViewItem Header = "Duck">< / TreeViewItem>
		< / TreeViewItem>
		<TreeViewItem Header = "Cars">
			<TreeViewItem Header = "Mustang">< / TreeViewItem>
			<TreeViewItem Header = "Corolla">< / TreeViewItem>
			<TreeViewItem Header = "Smart">
				<TreeView>													// Nested tree view
					<TreeViewItem Header = "two door">< / TreeViewItem>
					<TreeViewItem Header = "four door">< / TreeViewItem>
					<TreeViewItem Header = "Wagon">< / TreeViewItem>
				< / TreeView>
			< / TreeViewItem>
		< / TreeViewItem>
	< / TreeView>
< / Grid>
//********************************************	
// Status bar
//********************************************
<Grid>
<StatusBar Name = "Statusbar"
VerticalAlignment = "Bottom"
Background = "Yellow">
<StatusBarItem>
<TextBlock Text = "Downloading file" / >
< / StatusBarItem>
<StatusBarItem>
<ProgressBar Width = "100"
Height = "20"
Name = "ProgressBar">
<ProgressBar.Triggers>
<EventTrigger RoutedEvent = "ProgressBar.Loaded">
<BeginStoryboard>
<Storyboard>
<DoubleAnimation Storyboard.TargetName = "ProgressBar"
Storyboard.TargetProperty = "Value"
From = "0"
To = "100"
Duration = "0:0:10" / >
< / Storyboard>
< / BeginStoryboard>
< / EventTrigger>
< / ProgressBar.Triggers>
< / ProgressBar>
< / StatusBarItem>
<Separator / >
<StatusBarItem>
<TextBlock>Online< / TextBlock>
< / StatusBarItem>
<StatusBarItem HorizontalAlignment = "Right">
<Button Content = "Help"
Name = "Help"
Click = "Help_Click" / >

< / StatusBarItem>
< / StatusBar>
< / Grid>
//********************************************	
// Menu
//********************************************
<Menu Background = "Coral">
<MenuItem Header = "File">
<MenuItem Header = "New..." / >
<MenuItem Header = "Open..." / >
<Separator / >
<MenuItem Header = "Add">
<MenuItem Header = "Motorcycle" / >
<MenuItem Header = "Helicoptor" / >
< / MenuItem>
<Separator / >
<MenuItem Header = "Save as you go"
IsCheckable = "True" / >
< / MenuItem>
<MenuItem Header = "Edit">
<MenuItem Header = "Cut">< / MenuItem>
<MenuItem Header = "Copy">< / MenuItem>
<MenuItem Header = "Paste">< / MenuItem>
< / MenuItem>
< / Menu>
//********************************************	
// Context Menu
//********************************************
<ListBox>
<ListBox.ContextMenu>
<ContextMenu>
<MenuItem Header = "File">
<MenuItem Header = "New..." / >
<MenuItem Header = "Open..." / >
<Separator / >
<MenuItem Header = "Add">
<MenuItem Header = "Motorcycle" / >
<MenuItem Header = "Helicoptor" / >
< / MenuItem>
<Separator / >
<MenuItem Header = "Save as you go"
IsCheckable = "True" / >
< / MenuItem>
<MenuItem Header = "Edit">
<MenuItem Header = "Cut">< / MenuItem>
<MenuItem Header = "Copy">< / MenuItem>
<MenuItem Header = "Paste">< / MenuItem>
< / MenuItem>
< / ContextMenu>
< / ListBox.ContextMenu>
<ListBoxItem Content = "Item 1" / >
<ListBoxItem Content = "Item 2" / >
<ListBoxItem Content = "Item 3" / >
< / ListBox>
//********************************************	
// 
//********************************************

//********************************************	
// 
//********************************************

//********************************************	
// 
//********************************************

//********************************************	
// 
//********************************************

//********************************************	
// 
//********************************************

