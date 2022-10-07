import{d as t}from"./dom-f057d094.js";import{k as e,R as s,f as i,u as o}from"./dom-utils-ab21af24.js";import{d as n}from"./disposable-d2c2d283.js";import{L as l,U as r}from"./layout-builder-70a2fbb7.js";import{initFocusHidingEvents as h}from"./focus-utils-4e0290d1.js";import"./_tslib-bfc426b4.js";import"./touch-4741c1ba.js";class a extends l{constructor(t,e,s){super(t),this.nextBlock=null,this.prevBlock=null,this.ribbonOwner=t,this.group=e,this.element=s,this.width=0,this.isActiveValue=null,this.index=e.blocks.length,this.nextBlock=null,this.prevBlock=s.layoutBlockObj||null,this._element=s,this._element.layoutBlockObj=this._element.layoutBlockObj?this._element.layoutBlockObj.nextBlock=this:this,this._element.onHide=()=>{this.toggleClassName(this.element,"ta-hidden-item",!0)},this._element.onShow=()=>{this.toggleClassName(this.element,"ta-hidden-item",!1)}}afterCreate(t){delete this._element.layoutBlockObj,t.maxWidth+=this.width,t.minWidth+=this.getMinWidth(),0===this.width&&this.raiseVisibilityChange(!1)}setActive(t){this.isActiveValue!==t&&(this.isActiveValue=t,this.group.activeBlock=t?this:null,this.group.groupsCollection.lastGroup=this.group,this.group.state.prevState&&this.toggleClassName(this.group.element.parentNode,this.group.state.prevState.name,this.isActiveValue),this.toggleClassName(this.element,this.group.state.name,this.isActiveValue),this.toggleClassName(this.group.element,this.group.state.name,this.isActiveValue))}raiseVisibilityChange(t){var e,s;const i=t?this._element.onShow:this._element.onHide;i&&(null===(e=this.owner)||void 0===e||e.domChanges.push(i)),null===(s=this.ribbonOwner)||void 0===s||s.toggleVisibility(this.element,t)}getMinWidth(){return this.nextBlock?this.nextBlock.getMinWidth():this.width}getNextBlock(t){let e=this.group,s=e.blocks[this.index-t];return!s&&(e=e.groupsCollection.blockGroups[e.totalIndex+t])&&(s=e.blocks[Math.pow(e.blocks.length,t>0?1:0)-1]),s}}class u extends l{constructor(t,e,s,i){super(t),this.builders=e||[],this.name=s,this.index=i?i.index+1:0,this.prevState=i,this.nextState=null,i&&(i.nextState=this)}for(t){return this.builders[this.builders.length]=this.createLayoutEntity(p,this.owner,this.name,t)}}class c extends l{constructor(t,e,s,i,o){super(t),this.groupsCollection=e,this.state=i,this.element=s,this.elementOffset=this.getBoxOffset(s),this.blocks=[],this.activeBlock=null,this.fullWidth=this.elementOffset,this.isSmallest=!i.nextState,this.isLargest=!i.prevState,this.domIndex=o,this.totalIndex=this.groupsCollection.blockGroups.length,this.createBlocks(i.builders);const n=s;i.prevState&&(this.isSmallest||(n.layoutBlockGroupObj.isSmallest=0===this.blocks.length))?delete n.layoutBlockGroupObj:n.layoutBlockGroupObj=this}afterCreate(t){this.blocks.forEach((function(e){e.afterCreate(t)})),t.groupsOffset+=this.elementOffset,t.groupBlocksLengthLookup[this.domIndex]=this.blocks.length,t.lastGroup=this}setActive(t){let e=0;!this.isSmallest&&this.isLargest&&(e=this.blocks.length-1),this.blocks[e].setActive(t)}createBlocks(t){for(let e=0;e<t.length;e++){const s=t[e],i=s.findBlockElements(this.element);for(let t=0;t<i.length;t++){const e=this.createLayoutEntity(a,this.owner,this,i[t]);this.fullWidth+=e.width=s.getBlockWidth(e),this.blocks.push(e)}}this.isLargest&&this.setActive(!0)}calculateWidth(t){return this!==t.group?this.fullWidth:this.getActualBlocks(t).reduce((function(t,e){return t+e.width}),this.elementOffset)}getActualBlocks(t){return this.blocks.map(function(e){return e.prevBlock&&e.index<t.index?e.prevBlock:e}.bind(this))}}class d extends l{constructor(t,e,s){super(t),this.ribbonOwner=t,this.groupsContainer=e,this.testElement="function"==typeof s?s:function(t){return r.elementMatchesSelector(t,s)},this.blockGroups=[],this.states=[],this.width=0,this.groupsOffset=0,this.maxWidth=0,this.minWidth=0,this.groupElementsCount=0,this.currentLayoutElements=[],this.lastGroup=null,this.selector=s,this.groupLookupMap={},this.groupBlocksLengthLookup={}}createBlockGroup(t,e,s){let i=this.createLayoutEntity(c,this.owner,this,t,e,s);return i&&(i=i.blocks.length>0?this.blockGroups[this.blockGroups.length]=i:null),i&&(this.groupLookupMap[s]||(this.groupLookupMap[s]=[])).splice(0,0,i.totalIndex),i}createBlockGroups(){var t;const e=null===(t=this.ribbonOwner)||void 0===t?void 0:t.getGroupElements(this.groupsContainer,this.selector);if(e){this.groupElementsCount=e.length;for(let t=0;t<this.states.length;t++)for(let s=this.groupElementsCount-1;s>=0;s--){const i=e[s];!i||this.testElement(i)&&this.createBlockGroup(i,this.states[t],s)||(e[s]=null)}this.states=[];for(let t=0;t<this.blockGroups.length&&this.blockGroups[t].isLargest;t++)this.blockGroups[t].afterCreate(this);this.minWidth+=this.groupsOffset,this.maxWidth+=this.groupsOffset,this.width=this.maxWidth,this.currentLayoutElements=this.findActiveBlocks()}}defineState(t,e){const s=this.createLayoutEntity(u,this.owner,[],t,this.states[this.states.length-1]||null);this.states.push(s),e(s)}initialize(){}applyLayout(t){this.currentLayoutElements&&this.currentLayoutElements.forEach((function(t){t.setActive(!1)})),this.currentLayoutElements=t,this.currentLayoutElements.forEach((function(t){t.setActive(!0)})),this.detectBlockItemVisibilityChanges()}adjust(t){if(t===this.width||t<=this.minWidth&&this.width===this.minWidth||t>=this.maxWidth&&this.width===this.maxWidth)return;const e=this.width;if(this.width=Math.max(this.minWidth,Math.min(this.maxWidth,t)),this.width===this.maxWidth)return this.applyLayout(this.blockGroups.filter((function(t){return t.isLargest})));if(this.width===this.minWidth)return this.applyLayout(this.blockGroups.filter((function(t){return t.isSmallest})));const s=e-this.width,i=s/Math.abs(s),o=this.findActiveBlocks();let n=o?o[0]:null,l=n;const r=n;for(;n;){if(t=this.calculateWidth(n),i>0&&t<=this.width||i<0&&t>=this.width){const t=i<0?l:n;t!==r&&null!==t&&this.applyLayout([t]);break}l=n,n=n.getNextBlock(i)}}detectBlockItemVisibilityChanges(){const t=this.findActualBlockGroups();for(let e=0;e<t.length;e++){const s=t[e];let i=!1;for(let t=0;t<s.blocks.length;t++){let e=s.blocks[t];s!==this.lastGroup||(i=i||e.isActiveValue)||(e=e.prevBlock||e),e.raiseVisibilityChange(e.width>0)}}}calculateWidth(t){if(!t){const e=this.findActiveBlocks();e&&(t=e[0])}return this.findActualBlockGroups(t.group).reduce((function(e,s){return e+s.calculateWidth(t)}),0)}findActualBlockGroups(t=null){const e=[];if(!(t=t||this.lastGroup))return e;for(let s=0;s<this.groupElementsCount;s++){const i=this.groupLookupMap[s];for(let o=0;o<i.length;o++){const n=this.blockGroups[i[o]];if(s<t.domIndex?n.state.index<t.state.index:n.state.index<=t.state.index){e.push(n);break}}}return e}findActiveBlocks(){return this.lastGroup?this.lastGroup.blocks.filter((function(t){return t.isActiveValue})):null}dispose(){}}class p extends l{constructor(t,e,s){super(t),this.name=e,this.selectorOrFunc=s,this.prepareBlockFunc=null}getBlockWidth(t){return this.prepareBlockFunc?this.prepareBlockFunc(t):0}findBlockElements(t){const e=r.getChildElementNodesByPredicate(t,(t=>r.elementMatchesSelector(t,this.selectorOrFunc)));return null!=e?e:[]}setPrepareFunc(t){return this.prepareBlockFunc=t,this}setWidth(){return this.setPrepareFunc((t=>this.getBoxSize(t.element)))}setHidden(){return this.setPrepareFunc((function(t){return 0}))}setOnlyImageWidth(){return this.setPrepareFunc((t=>{let e=this.getBoxSize(t.element),s=r.getChildByClassName(t.element,"image:not(.preview-image)");s||(s=r.getChildByClassName(r.getChildByClassName(t.element,"dropdown-toggle"),"image:not(.preview-image)"));let i=r.getChildByClassName(t.element,"preview-image");if(i||(i=r.getChildByClassName(r.getChildByClassName(t.element,"dropdown-toggle"),"preview-image")),s){if(e=this.getBoxSize(s)-this.getBoxOuterOffset(s),i){const t=this.getBoxSize(i)-this.getBoxOuterOffset(i);e=Math.max(e,t)}let o=this.getBoxOffset(t.element),n=s.parentNode;for(;n!==t.element;)o+=this.getBoxOffset(n),n=n.parentNode;return e+o}return e}))}setNoTextWidth(){return this.setPrepareFunc((t=>{let e=this.getBoxSize(t.element);if(r.getChildByClassName(t.element,"dx-toolbar-edit"))return e;let s=r.getChildByClassName(t.element,"image");if(s||(s=r.getChildByClassName(r.getChildByClassName(t.element,"btn"),"image")),s){const t=s.nextElementSibling;t&&(e-=this.getBoxSize(t),e-=this.getBoxOuterOffset(s))}return e}))}}class g extends l{constructor(t){super(null),this.clientStateMap=new Map,this.dotNetReference=t.dotNetReference,this.container=t.getMainElement(),this.containerOffsets=this.calculateContainerOffsets(),this.blockGroupsArray=[],this.isReady=!1,this.classesToApply=[],this.domChanges=[],this.nextAdjustGroupWidth=null}getClientState(t){const e=t.dataset.dxtoolbarItemId;if(!e)return null;let s=this.clientStateMap.get(e);return s||(s={id:e},this.clientStateMap.set(e,s)),s}toggleClassNameInternal(t,e,s){this.getBatchCssUpdateCache(t)[e]=s;const i=this.getClientState(t);i&&(i[e]=s)}getBatchCssUpdateCache(t){let e=t._layoutBuilderCache;return e||(e=t._layoutBuilderCache={},this.classesToApply.push(this.createBatchCssUpdateDelegate(t))),e}createBatchCssUpdateDelegate(e){return function(){const s=e._layoutBuilderCache;if(s){delete e._layoutBuilderCache;for(const i in s)Object.prototype.hasOwnProperty.call(s,i)&&t.DomUtils.toggleClassName(e,i,s[i])}}}createBlockGroupsCore(t,e,s){const i=[],o=this.querySelectorAll(t);for(let t=0;t<o.length;t++){const n=this.createLayoutEntity(d,this,o[t],e);this.blockGroupsArray.push(n),s&&s(n),n.createBlockGroups(),i.push(n)}return this.nextAdjustGroupWidth=this.getGroupsWidth(),i}initialize(){for(let t=0;t<this.blockGroupsArray.length;t++)this.blockGroupsArray[t].initialize();this.isReady=!0,this.adjust()}adjust(t=null){if(this.isReady){const s=this.classesToApply,i=this.domChanges;let o=this.classesToApply=[],n=this.domChanges=[];const l=this.clientStateMap;let r;null!==this.nextAdjustGroupWidth?(r=this.nextAdjustGroupWidth,this.nextAdjustGroupWidth=null):r=this.getGroupsWidth();for(let t=0;t<this.blockGroupsArray.length;t++)this.blockGroupsArray[t].adjust(r);t&&t(),o=s.concat(o),n=i.concat(n);const h=Array.from(l.values()).concat(Array.from(this.clientStateMap.values()));this.queueUpdates((()=>{for(;o.length;){const t=o.shift();t&&t()}this.queueUpdates((()=>{for(;n.length;){const t=n.shift();t&&t()}h.length&&this.dotNetReference.invokeMethodAsync("OnModelUpdated",h).catch((t=>{e(this.container)||console.error(t)}))}))}))}}toggleVisibility(t,e){const s=this.getClientState(t);s&&(s.isVisible=e)}queueUpdates(t){s(t)}getGroupsWidth(){const t=this.getContainer();return t?t.offsetWidth-this.containerOffsets:0}dispose(){this.containerOffsets=this.calculateContainerOffsets();for(let t=0;t<this.blockGroupsArray.length;t++)this.blockGroupsArray[t].dispose();this.blockGroupsArray=[],this.isReady=!1}getGroupElements(t,e){return r.getChildElementNodesByPredicate(t,(function(t){return r.elementMatchesSelector(t,e)}))}createBlockGroups(){this.createBlockGroupsCore(".dxbs-toolbar > .btn-toolbar",".dxbs-toolbar-group",(function(t){t.defineState("item",(function(t){t.for(":not(.dxbs-ta-ag)").setWidth(),t.for(".dxbs-ta-ag").setHidden()})),t.defineState("item-text-h",(function(t){t.for(":not(.dxbs-ta-ag)").setNoTextWidth(),t.for(".dxbs-ta-ag").setHidden()})),t.defineState("item-h",(function(t){t.for(":only-child:not(.dxbs-ta-ag)").setWidth(),t.for(":not(:only-child):not(.dxbs-ta-ag)").setHidden(),t.for(".dxbs-ta-ag").setWidth()})),t.defineState("item-a",(function(t){t.for(":only-child:not(.dxbs-ta-ag)").setNoTextWidth(),t.for(":not(:only-child):not(.dxbs-ta-ag)").setHidden(),t.for(".dxbs-ta-ag").setNoTextWidth()}))}))}calculateContainerOffsets(){var t;if(!this.container)return 0;let e=this.getBoxInnerOffset(this.container),s=null!==(t=this.container.querySelector(".dxbs-toolbar"))&&void 0!==t?t:this.container;for(;s!==this.container&&s;)e+=this.getBoxOffset(s),s=s.parentNode;return e}}class m{constructor(t,e){this.currentWidth=null,this.currentHeight=null,this.elementContentWidthSubscription=null,this.mainElement=t,this.layoutBreakPoints=null,this.dotNetReference=e}getMainElement(){return this.mainElement}initialize(){s((()=>{this.buildLayout()})),s((()=>{this.adjustLayout()})),this.elementContentWidthSubscription=i(this.getMainElement(),(t=>{this.currentWidth===t.width&&this.currentHeight===t.height||(this.currentWidth=t.width,this.currentHeight=t.height,this.onBrowserWindowResize())}))}applyLayoutStateAppearance(){var e;t.DomUtils.addClassName(this.getMainElement(),"dxbs-loaded"),null===(e=this.layoutBreakPoints)||void 0===e||e.initialize(),setTimeout((()=>{t.DomUtils.removeClassName(this.getMainElement(),"dxbs-loading")}),500)}onBrowserWindowResize(){this.layoutBreakPoints&&this.layoutBreakPoints.adjust()}update(){this.layoutBreakPoints&&this.layoutBreakPoints.adjust()}dispose(){this.elementContentWidthSubscription&&o(this.elementContentWidthSubscription),this.layoutBreakPoints&&this.layoutBreakPoints.dispose()}buildLayout(){this.layoutBreakPoints=this.layoutBreakPoints||new g(this),this.layoutBreakPoints.createBlockGroups()}adjustLayout(){var t;this.applyLayoutStateAppearance(),null===(t=this.layoutBreakPoints)||void 0===t||t.adjust()}}const f=new Map;function k(t,e,s){if(!t)return Promise.reject("failed");let i=f.get(t);i?i.update():(i=new m(t,s),i.initialize(),f.set(t,i));const o=t.querySelector(".btn-toolbar")||t;return h(o),Promise.resolve("ok")}function b(t){return s(t,f),Array.from(f.keys()).forEach((t=>{e(t)&&s(t,f)})),Promise.resolve("ok");function s(t,e){if(!t)return;const s=t.querySelector(".btn-toolbar");s&&n(s);const i=e.get(t);null==i||i.dispose(),e.delete(t)}}const y={init:k,dispose:b};export{y as default,b as dispose,k as init};