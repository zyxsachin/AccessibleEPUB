var currentCSS = '@import url("visible.css");';

function loadCSS() {
	var mycss;

//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].title=="style.css") 
//			mycss=document.styleSheets[i] 
//			break;
//	}

	for (i=0; i<document.styleSheets.length; i++){
		if (document.styleSheets[i].cssRules.length==1) 
			mycss=document.styleSheets[i] 
			break;
	}

	//var currentSheet = document.getElementById("stylesheet"),
	//currentSheet.appendChild('@import url("visible.css");');
	var sheet = document.styleSheets[0].cssRules;
	
	//document.getElementById("Test").innerHTML=mycss;
	mycss.deleteRule(0);
	mycss.insertRule(currentCSS,0);
}

function selectVisible() {
	// Prepare to dynamically load CSS.
//	var fileref = document.createElement("link");
//	fileref.setAttribute("rel", "stylesheet");
	//fileref.setAttribute("type", "text/css");
				
	
	//fileref.setAttribute("href", "../Styles/visible.css");
	//document.getElementsByTagName("head")[0].appendChild(fileref);

//	var mycss;

//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].title=="style.css") 
//			mycss=document.styleSheets[i] 
//			break;
//	}

//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].cssRules.length==1) 
//			mycss=document.styleSheets[i] 
//			break;
//	}

	//var currentSheet = document.getElementById("stylesheet"),
	//currentSheet.appendChild('@import url("visible.css");');
//	var sheet = document.styleSheets[0].cssRules;
	
	//document.getElementById("Test").innerHTML=mycss;
//	mycss.deleteRule(0);
//	mycss.insertRule('@import url("visible.css");',0);
	
	currentCSS = '@import url("visible.css");';
	loadCSS();
}

function selectImpaired() {
	// Prepare to dynamically load CSS.
//	var fileref = document.createElement("link");
//	fileref.setAttribute("rel", "stylesheet");
	//fileref.setAttribute("type", "text/css");
				
	
	//fileref.setAttribute("href", "../Styles/impaired.css");
	//document.getElementsByTagName("head")[0].appendChild(fileref);
	//var currentSheet = document.getElementById("stylesheet"),
	//currentSheet.appendChild('@import url("impaired.css");');
//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].title=="style.css") 
//			mycss=document.styleSheets[i] 
//			break;
//	}

//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].cssRules.length==1) 
//			mycss=document.styleSheets[i] 
//			break;
//	}

	//var currentSheet = document.getElementById("stylesheet"),
	//currentSheet.appendChild('@import url("visible.css");');
//	var sheet = document.styleSheets[0].cssRules;
	
	//document.getElementById("Test").innerHTML=mycss;
//	mycss.deleteRule(0);
//	mycss.insertRule('@import url("impaired.css");',0);

	currentCSS = '@import url("impaired.css");';
	loadCSS();
				
}

function selectBlind() {
	// Prepare to dynamically load CSS.
//	var fileref = document.createElement("link");
//	fileref.setAttribute("rel", "stylesheet");
	//fileref.setAttribute("type", "text/css");
				
	
	//fileref.setAttribute("href", "../Styles/blind.css");
	//document.getElementsByTagName("head")[0].appendChild(fileref);
//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].title=="style.css") 
//			mycss=document.styleSheets[i] 
//			break;
//	}

//	for (i=0; i<document.styleSheets.length; i++){
//		if (document.styleSheets[i].cssRules.length==1) 
//			mycss=document.styleSheets[i] 
//			break;
//	}

	//var currentSheet = document.getElementById("stylesheet"),
	//currentSheet.appendChild('@import url("visible.css");');
//	var sheet = document.styleSheets[0].cssRules;
	
	//document.getElementById("Test").innerHTML=mycss;
//	mycss.deleteRule(0);
//	mycss.insertRule('@import url("blind.css");',0);

	currentCSS = '@import url("blind.css");';
	loadCSS();
				
}