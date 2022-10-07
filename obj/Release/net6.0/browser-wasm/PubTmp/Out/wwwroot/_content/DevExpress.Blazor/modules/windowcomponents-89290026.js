import{a as t}from"./_tslib-bfc426b4.js";import{D as o,a as e}from"./popup-a7619af7.js";import{B as s,a as r}from"./popuproot-e4bfd720.js";import{i}from"./query-8cb4c1ca.js";import{n as l,e as p}from"./property-0899c55e.js";import{$ as a,s as n,r as d}from"./lit-element-42a89b46.js";import{D as b}from"./popupbasedialog-4a39b856.js";import{dxBranchTagName as m}from"./branch-bb1eefec.js";import"./rect-2684652a.js";import"./point-9c6ab88a.js";import"./rafaction-bba7928b.js";import"./transformhelper-3935ca6a.js";import"./layouthelper-c2462bd3.js";import"./positiontracker-9570b24e.js";import"./positiontrackerobserver-5fd93b2c.js";import"./elementobserver-5f004683.js";import"./supportcaptureelement-e000b699.js";import"./dx-ui-element-fa46d41b.js";import"./lit-element-base-cc37ea0b.js";import"./data-qa-utils-8be7c726.js";import"./capturemanager-470a5b3f.js";import"./eventhelper-450cce9f.js";let h=class extends o{renderTemplate(){return a`
            <dxbl-branch
                id="${this.branchId}"
                parent-id="${this.parentBranchId}"
                type="${s.Window}">
                <dxbl-window-root
                    id="root"
                    style="${this.rootCssStyle}"
                    resizing="${this.resizing}"
                    drop-opposite="${this.actualDropOpposite}"
                    drop-direction="${this.actualDropDirection}">
                    ${this.renderSlot()}
                </dxbl-window-root>
            </dxbl-branch>
        `}get child(){return this.root}renderSlot(){return a`
            <slot></slot>
            <slot name="top" slot="top"></slot>
            <slot name="right" slot="right"></slot>
            <slot name="bottom" slot="bottom"></slot>
            <slot name="left" slot="left"></slot>
            <slot name="top-left" slot="top-left"></slot>
            <slot name="top-right" slot="top-right"></slot>
            <slot name="bottom-left" slot="bottom-left"></slot>
            <slot name="bottom-right" slot="bottom-right"></slot>
        `}};t([i("#root",!0)],h.prototype,"root",void 0),h=t([l("dxbl-window")],h);let c=class extends b{};c=t([l("dxbl-dropdown-dialog")],c);let u=class extends n{constructor(){super(...arguments),this.topLeftClass=null,this.topRightClass=null,this.bottomLeftClass=null,this.bottomRightClass=null,this.dropOpposite=!1,this.dropDirection=e.Near,this.resizing=!1}static get styles(){return d`
            :host {
                display: flex;
                box-sizing: border-box;
            }
            .hidden {
                display: none;
            }
            ::slotted {
                min-width: 8px;
                min-height: 8px;
            }
            ::slotted([slot="top-left"]) {
                position: absolute;
                z-index: 1;
                top: 0px;
                left: 0px;
                transform: rotate(-90deg);
                cursor: nw-resize;
            }
            ::slotted([slot="top-right"]) {
                position: absolute;
                z-index: 1;
                top: 0px;
                right: 0px;
                transform: rotate(-180deg);
                cursor: ne-resize;
            }
            ::slotted([slot="bottom-left"]) {
                position: absolute;
                z-index: 1;
                bottom: 0px;
                left: 0px;
                transform: rotate(-270deg);
                cursor: sw-resize;
            }
            ::slotted([slot="bottom-right"]) {
                position: absolute;
                z-index: 1;
                bottom: 0px;
                right: 0px;
                cursor: se-resize;
                transform: rotate(0deg);
            }
        }`}connectedCallback(){super.connectedCallback(),this.calculateStyles(this.resizing,this.dropOpposite,this.dropDirection)}willUpdate(t){(t.has("dropOpposite")||t.has("dropDirection")||t.has("resizing"))&&this.calculateStyles(this.resizing,this.dropOpposite,this.dropDirection)}calculateStyles(t,o,s){this.topLeftClass=t&&o&&s===e.Far?null:"hidden",this.topRightClass=t&&o&&s===e.Near?null:"hidden",this.bottomLeftClass=t&&!o&&s===e.Far?null:"hidden",this.bottomRightClass=t&&!o&&s===e.Near?null:"hidden"}render(){return a`
            <slot></slot>
            <dxbl-thumb>
                <slot name="top"></slot>
            </dxbl-thumb>
            <dxbl-thumb>
                <slot name="right"></slot>
            </dxbl-thumb>
            <dxbl-thumb>
                <slot name="bottom"></slot>
            </dxbl-thumb>
            <dxbl-thumb>
                <slot name="left"></slot>
            </dxbl-thumb>
            <dxbl-thumb class="${this.topLeftClass}">
                <slot name="top-left"></slot>
            </dxbl-thumb>
            <dxbl-thumb class="${this.topRightClass}">
                <slot name="top-right"></slot>
            </dxbl-thumb>
            <dxbl-thumb class="${this.bottomLeftClass}">
                <slot name="bottom-left"></slot>
            </dxbl-thumb>
            <dxbl-thumb class="${this.bottomRightClass}">
                <slot name="bottom-right"></slot>
            </dxbl-thumb>`}};t([p({type:String,reflect:!1})],u.prototype,"topLeftClass",void 0),t([p({type:String,reflect:!1})],u.prototype,"topRightClass",void 0),t([p({type:String,reflect:!1})],u.prototype,"bottomLeftClass",void 0),t([p({type:String,reflect:!1})],u.prototype,"bottomRightClass",void 0),t([p({type:Object,attribute:"drop-opposite"})],u.prototype,"dropOpposite",void 0),t([p({type:String,attribute:"drop-direction"})],u.prototype,"dropDirection",void 0),t([p({type:Object,attribute:"resizing"})],u.prototype,"resizing",void 0),u=t([l("dxbl-window-root")],u);function f(t){return t}const g={getReference:f,registeredComponents:["dxbl-window","dxbl-dropdown-dialog",r,"dxbl-window-root",m]};export{g as default,f as getReference};
