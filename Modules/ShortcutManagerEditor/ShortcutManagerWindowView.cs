// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExCSS.Model.Extensions;
using UnityEditor.Experimental;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

namespace UnityEditor.ShortcutManagement
{
    //TODO: migrate those into USS.
    class StyleUtility
    {
        public static void NormalTextElement(VisualElement el)
        {
            StyleUtility.NormalTextColor(el);
            el.style.whiteSpace = WhiteSpace.NoWrap;
        }

        public static void NormalTextColor(VisualElement el)
        {
            if (EditorGUIUtility.isProSkin)
            {
                el.style.color = new Color(0.7058824f, 0.7058824f, 0.7058824f);
            }
            else
            {
                el.style.color = new Color(39f / 255f, 39f / 255f, 39f / 255f);
            }
        }

        public static void StyleVisible(VisualElement el)
        {
            el.style.visibility = Visibility.Visible;
            el.style.position = Position.Relative;
        }

        public static void StyleHidden(VisualElement el)
        {
            el.style.visibility = Visibility.Hidden;
            el.style.position = Position.Absolute;
        }

        public static void StyleColumnDirection(VisualElement el)
        {
            el.style.flexDirection = FlexDirection.Column;
        }

        public static void StyleRow(VisualElement row)
        {
            row.style.flexDirection = FlexDirection.Row;
        }

        public static void StyleReverseRowDirection(VisualElement el)
        {
            el.style.flexDirection = FlexDirection.RowReverse;
        }

        public static void StyleFlexibleElement(VisualElement el)
        {
            el.style.flexGrow = 1;
            el.style.flexBasis = 0f;
            el.style.justifyContent = Justify.Center;
        }

        public static void StyleFlexibleTableCell(VisualElement el)
        {
            StyleFlexibleElement(el);
            el.style.flexBasis = 0f;
            el.style.overflow = Overflow.Hidden;
        }

        public static void StyleResizeHandle(VisualElement el)
        {
            el.style.width = 10;
            el.style.position = Position.Absolute;
            el.style.cursor =
                new UnityEngine.UIElements.Cursor() { texture = null, hotspot = Vector2.zero, defaultCursorId = (int)MouseCursor.ResizeHorizontal };
            //UIElementsEditorUtility.CreateDefaultCursorStyle(MouseCursor.ResizeHorizontal);
            StyleHeaderHeight(el);
            StyleBorderColor(el);

            var visualElement = new VisualElement();
            StyleBorderColor(visualElement);
            visualElement.style.backgroundColor = visualElement.style.borderColor;
            StyleHeaderHeight(visualElement);
            visualElement.style.position = Position.Relative;
            visualElement.style.marginTop = visualElement.style.height.value.value * ((1f / 3) / 2);
            visualElement.style.marginLeft = el.style.width.value.value / 2;
            visualElement.style.width = 1;
            visualElement.style.height = visualElement.style.height.value.value * (2f / 3);
            visualElement.pickingMode = PickingMode.Ignore;
            el.Add(visualElement);
        }

        static void StyleBorderColor(VisualElement el)
        {
            if (EditorGUIUtility.isProSkin)
                el.style.borderColor = new Color(37f / 255f, 37f / 255f, 37f / 255f);
            else
                el.style.borderColor = new Color(211f / 255f, 211f / 255f, 211f / 255f);
        }

        public static void StyleHeaderCell(VisualElement el)
        {
            el.style.borderBottomWidth = 1;
            StyleHeaderHeight(el);
            StyleBorderColor(el);
        }

        public static void StyleHeaderHeight(VisualElement el)
        {
            el.style.height = 40;
        }

        public static void StyleHeaderText(VisualElement el)
        {
            el.style.unityTextAlign = TextAnchor.MiddleLeft;
            el.style.unityFontStyleAndWeight = FontStyle.Bold;

            StyleTextRow(el);
        }

        static void StyleBorderAround(VisualElement el)
        {
            StyleBorderWidths(el, 1);
            StyleBorderColor(el);
        }

        public static void StyleRootPanelPadding(VisualElement element)
        {
            const int padding = 20;
            element.style.paddingBottom = padding;
            element.style.paddingTop = padding;
            element.style.paddingRight = padding;
            element.style.paddingLeft = padding;
        }

        private static void StyleBorderRadius(VisualElement element, float radius)
        {
            element.style.borderTopLeftRadius = radius;
            element.style.borderTopRightRadius = radius;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderBottomRightRadius = radius;
        }

        public static void StylePanel(VisualElement element)
        {
            StyleBorderAround(element);

            if (EditorGUIUtility.isProSkin)
                element.style.backgroundColor = new Color(70f / 255f, 70f / 255f, 70f / 255f);
            else
                element.style.backgroundColor = new Color(229f / 255f, 229f / 255f, 229f / 255f);

            StyleBorderRadius(element, 5f);
        }

        public static void StyleTextRowNoPadding(VisualElement el)
        {
            NormalTextElement(el);
            el.style.unityTextAlign = TextAnchor.MiddleLeft;
        }

        public static void StyleTextRow(VisualElement el)
        {
            StyleTextRowNoPadding(el);
            el.style.paddingRight = 10f;
            el.style.paddingLeft = 10f;
        }

        public static void StyleSearchContainer(VisualElement el)
        {
            el.style.flexBasis = 1f;
            el.style.flexGrow = 0.2f;
            el.style.marginTop = 10;
            el.style.marginBottom = 10;
            StyleRow(el);
        }

        public static void StyleConflictLabel(TextElement el)
        {
            el.style.color = new Color(1, 0, 0);
        }

        public static void StyleHeaderIcon(VisualElement el)
        {
            el.style.width = 16;
            el.style.height = 16;
        }

        public static void RightMarginBetweenTables(VisualElement el)
        {
            el.style.marginRight = 5;
        }

        #region Styles specific to a single element

        public static void StyleShortcutEntryTable(VisualElement el)
        {
            StyleFlexibleElement(el);
            el.style.flexGrow = 3;
            RightMarginBetweenTables(el);
            StylePanel(el);
        }

        public static void StyleRootPanel(VisualElement el)
        {
            StyleColumnDirection(el);
            StyleFlexibleElement(el);
            StyleRootPanelPadding(el);
        }

        public static void StyleShortcutEntriesContainer(VisualElement el)
        {
            StyleRow(el);
            StyleFlexibleElement(el);
        }

        #endregion

        public static void StyleCategoryContainer(VisualElement el)
        {
            StyleColumnDirection(el);
            StyleFlexibleElement(el);
            RightMarginBetweenTables(el);
            StylePanel(el);
        }

        private static void StyleBorderWidths(VisualElement el, float borderWidth)
        {
            el.style.borderLeftWidth = borderWidth;
            el.style.borderBottomWidth = borderWidth;
            el.style.borderTopWidth = borderWidth;
            el.style.borderRightWidth = borderWidth;
        }

        static void StyleThinBorder(VisualElement el)
        {
            StyleBorderWidths(el, 1);
        }

        internal const int k_KeySize = 34;

        public static void StyleKey(VisualElement el)
        {
            el.style.width = k_KeySize;

            StyleThinBorder(el);

            StyleBorderRadius(el, 5);

            el.style.unityTextAlign = TextAnchor.MiddleCenter;
            el.style.whiteSpace = WhiteSpace.Normal;

            StyleNormal(el);
        }

        public static void StyleVerticalKeySizing(VisualElement keyElement)
        {
            keyElement.style.height = k_KeySize;

            keyElement.style.marginRight = 2;
            keyElement.style.marginBottom = 1;
            keyElement.style.marginTop = 1;
        }

        public static void StyleDefault(VisualElement key)
        {
            NormalTextElement(key);
        }

        public static void StyleNormal(VisualElement keyElement)
        {
            if (EditorGUIUtility.isProSkin)
            {
                keyElement.style.backgroundColor = new Color(93f / 255f, 93f / 255f, 93f / 255f);
                keyElement.style.borderColor = new Color(56f / 255f, 56f / 255f, 56f / 255f);
                keyElement.style.color = Color.white;
            }
            else
            {
                keyElement.style.backgroundColor = new Color(237f / 255f, 237f / 255f, 237f / 255f);
                keyElement.style.borderColor = new Color(165f / 255f, 165f / 255f, 165f / 255f);
            }
            StyleThinBorder(keyElement);
        }

        public static void StyleHover(VisualElement keyElement)
        {
            keyElement.style.borderColor = new Color(117f / 255f, 184f / 255f, 255f / 255f);
        }

        public static void StyleSelected(VisualElement keyElement)
        {
            keyElement.style.borderColor = new Color(60f / 255f, 153f / 255f, 252f / 255f);

            StyleBorderWidths(keyElement, 2);
        }

        public static void StyleBoundToContext(VisualElement keyElement)
        {
            if (EditorGUIUtility.isProSkin)
                keyElement.style.backgroundColor = new Color(148f / 255f, 162f / 255f, 178f / 255f);
            else
                keyElement.style.backgroundColor = new Color(206f / 255f, 216f / 255f, 221f / 255f);
        }

        public static void StyleBoundGlobally(VisualElement keyElement)
        {
            if (EditorGUIUtility.isProSkin)
                keyElement.style.backgroundColor = new Color(176f / 255f, 156f / 255f, 147f / 255f);
            else
                keyElement.style.backgroundColor = new Color(255f / 255f, 221f / 255f, 209f / 255f);
        }

        public static void StyleModifierActive(VisualElement keyElement)
        {
            if (EditorGUIUtility.isProSkin)
                keyElement.style.backgroundColor = new Color(109f / 255f, 155f / 255f, 246f / 255f);
            else
                keyElement.style.backgroundColor = new Color(187f / 255f, 221f / 255f, 252f / 255f);
        }

        public static void StyleSystemReserved(VisualElement keyElement)
        {
            var backgroundColor = EditorGUIUtility.isProSkin ? new Color(76f / 255f, 76f / 255f, 76f / 255f) : new Color(208f / 255f, 208f / 255f, 208f / 255f);
            var textColor = EditorGUIUtility.isProSkin ? new Color(90f / 255f, 90f / 255f, 90f / 255f) : new Color(109f / 255f, 109f / 255f, 109f / 255f);
            keyElement.style.backgroundColor = backgroundColor;
            keyElement.style.color = textColor;
        }

        public static void StyleModifier(VisualElement keyElement)
        {
            var backgroundColor = EditorGUIUtility.isProSkin ? new Color(74f / 255f, 74f / 255f, 74f / 255f) : new Color(204f / 255f, 204f / 255f, 204f / 255f);
            keyElement.style.backgroundColor = backgroundColor;
        }

        public static void StyleKeyFlexibleWidth(VisualElement spacer)
        {
            StyleVerticalKeySizing(spacer);
            spacer.style.flexGrow = 1;
        }

        public static void StyleSpace(VisualElement keyElement)
        {
            keyElement.style.flexGrow = 7;
        }

        public static void StyleCompactContainer(VisualElement compactContainer)
        {
            compactContainer.style.marginRight = 10;
        }

        public static void StyleKeyboardElement(VisualElement el)
        {
            el.style.alignItems = Align.Center;
        }

        public static void StyleKeyboardFirstRow(VisualElement el)
        {
            el.style.marginBottom = 10;
        }

        public static void StyleSearchEndingCancelButtonVisible(VisualElement el)
        {
            if (EditorGUIUtility.isProSkin)
                el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.darkSkinSourcePath + "Images/toolbarsearchCancelButton.png");
            else
                el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.lightSkinSourcePath + "Images/toolbarsearchCancelButton.png");
        }

        public static void StyleSearchEnding(VisualElement el)
        {
            if (EditorGUIUtility.isProSkin)
                el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.darkSkinSourcePath + "Images/toolbarsearchCancelButtonOff.png");
            else
                el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.lightSkinSourcePath + "Images/toolbarsearchCancelButtonOff.png");
            el.style.width = 14;
            el.style.height = 14;
            el.style.marginTop = 2;
        }

        public static void StyleSearchTextField(VisualElement el)
        {
            var input =  el.Q(TextField.textInputUssName);
            if (input != null)
            {
                input.style.backgroundImage = null;
                input.style.marginLeft = 0f;
                input.style.marginRight = 0f;
                input.style.marginTop = 1;
                input.style.fontSize = 9;
                input.style.flexGrow = 1;
                el.style.flexGrow = 1;
            }
        }

        public static void StyleActiveProfileDropdownButton(VisualElement el)
        {
            NormalTextColor(el);
            el.AddToClassList(PopupField<string>.textUssClassName);
            el.AddToClassList(PopupField<string>.inputUssClassName);
            FixPopupStyle(el);
        }

        public static void StyleSearchDropdown(VisualElement el)
        {
            if (EditorGUIUtility.isProSkin)
                el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.darkSkinSourcePath + "Images/toolbarsearchpopup.png");

            else
                el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.lightSkinSourcePath + "Images/toolbarsearchpopup.png");
            el.style.paddingLeft = 17;
            el.style.height = 14;
            el.style.unitySliceLeft = 15;
            el.style.marginTop = 2;
            el.style.flexGrow = 1;
        }

        public static void StyleHeaderLabelColor(VisualElement colorField)
        {
            colorField.style.width = 16;
            colorField.style.height = 16;
            colorField.style.marginRight = 5;
            colorField.style.marginLeft = 20;
        }

        public static void StyleFilterElement(VisualElement el)
        {
            StyleBorderAround(el);
            StyleBorderColor(el);
            StyleBorderRadius(el, 5);
            el.style.marginLeft = 10;
            el.style.paddingRight = 5;
            el.style.paddingLeft = 5;
            el.style.paddingTop = 2;
            el.style.paddingBottom = 2;
        }

        public static void StyleFilterElementSelected(VisualElement el)
        {
            el.style.backgroundColor = new Color(130f / 255f, 130f / 255f, 130f / 255f);
        }

        public static void StyleSearchFilterRow(VisualElement el)
        {
            StyleRow(el);
            el.style.borderBottomWidth = 1;
            StyleBorderColor(el);
        }

        public static void FixPopupStyle(VisualElement el)
        {
            el.style.paddingRight = el.resolvedStyle.paddingRight + 12;
            el.style.minWidth = 115;
            el.style.paddingBottom = 2;
        }

        public static void StyleProfileOptionsDropdown(VisualElement profileContextMenu)
        {
            profileContextMenu.style.unityBackgroundScaleMode = ScaleMode.ScaleToFit;
            if (EditorGUIUtility.isProSkin)
                profileContextMenu.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.iconsPath + "d__Popup.png");
            else
                profileContextMenu.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.iconsPath + "_Popup.png");
        }

        public static void StyleAsTextField(VisualElement el)
        {
            el.style.width = 100;
            el.style.height = 15;
            el.style.backgroundImage = (Texture2D)EditorGUIUtility.Load(EditorResources.lightSkinSourcePath + "Images/TextField.png");
            el.style.unitySliceLeft = 3;
            el.style.unitySliceRight = 3;
            el.style.unitySliceTop = 3;
            el.style.unitySliceBottom = 3;
            el.style.paddingLeft = 2;
            el.style.paddingRight = 2;
            el.style.paddingTop = 2;
            el.style.top = 2;
        }

        public static void StyleEntryOverriden(VisualElement el)
        {
            el.style.unityFontStyleAndWeight = FontStyle.Bold;
        }

        public static void StyleEntryNormal(VisualElement el)
        {
            el.style.unityFontStyleAndWeight = FontStyle.Normal;
        }
    }

    class ShortcutManagerWindowView : IShortcutManagerWindowView
    {
        const int k_ListItemHeight = 21;
        VisualElement m_Root;
        IShortcutManagerWindowViewController m_ViewController;
        IKeyBindingStateProvider m_BindingStateProvider;

        TextElement m_ActiveProfileDropdownButton;
        Keyboard m_KeyboardElement;
        ListView m_ShortcutsTable;
        TextField m_SearchTextField;

        bool m_StartedDrag;
        Vector2 m_MouseDownStartPos;
        ListView m_CategoryTreeView;
        VisualElement m_SearchCancelEnding;
        ShortcutTextField m_KeyBindingSearchField;
        ShortcutEntry m_EditingBindings;
        VisualElement m_SearchFiltersContainer;
        VisualElement m_ShortcutsTableSearchFilterContainer;
        HorizontalColumnDragger m_HorizontalColumnDragger;

        public ShortcutManagerWindowView(IShortcutManagerWindowViewController viewController, IKeyBindingStateProvider bindingStateProvider)
        {
            m_ViewController = viewController;
            m_BindingStateProvider = bindingStateProvider;
            BuildVisualElementHierarchyRoot();
            UpdateShortcutTableSearchFilter();
        }

        public VisualElement GetVisualElementHierarchyRoot()
        {
            return m_Root;
        }

        public void RefreshAll()
        {
            RefreshKeyboard();
            RefreshShortcutList();
            RefreshProfiles();
        }

        public void RefreshKeyboard()
        {
            m_KeyboardElement.Refresh();
        }

        public void RefreshCategoryList()
        {
            m_CategoryTreeView.selectedIndex = m_ViewController.selectedCategoryIndex;
            m_CategoryTreeView.Refresh();
        }

        public void RefreshShortcutList()
        {
            m_ShortcutsTable.Refresh();
            m_HorizontalColumnDragger.UpdatePositions();
        }

        public void UpdateSearchFilterOptions()
        {
            UpdateShortcutTableSearchFilter();
        }

        public RebindResolution HandleRebindWillCreateConflict(ShortcutEntry entry, IList<KeyCombination> newBinding, IList<ShortcutEntry> conflicts)
        {
            var title = L10n.Tr("Binding conflict");
            var message = string.Format(L10n.Tr("The key {0} is already assigned to the \"{1}\" shortcut.\nDo you want to reassign this key?"), KeyCombination.SequenceToString(newBinding), conflicts[0].identifier.path);
            var result = EditorUtility.DisplayDialogComplex(title, message, L10n.Tr("Reassign"), L10n.Tr("Cancel"), L10n.Tr("Create conflict"));
            switch (result)
            {
                case 0:
                    return RebindResolution.UnassignExistingAndBind;
                case 1:
                    return RebindResolution.DoNotRebind;
                case 2:
                    return RebindResolution.CreateConflict;
                default:
                    throw new Exception("Unrecognized option");
            }
        }

        VisualElement MakeItemForShortcutTable()
        {
            //TODO: Read from a uxml
            var shortcutNameCell = new TextElement();
            var bindingContainer = new VisualElement();
            var shortcutBinding = new TextElement();
            var rebindControl = new ShortcutTextField();

            bindingContainer.Add(shortcutBinding);
            bindingContainer.Add(rebindControl);
            StyleUtility.StyleRow(bindingContainer);

            StyleUtility.StyleTextRowNoPadding(shortcutBinding);
            StyleUtility.StyleAsTextField(rebindControl.input);
            StyleUtility.StyleHidden(rebindControl);

            shortcutBinding.style.flexGrow = 1;

            rebindControl.input.RegisterCallback<BlurEvent>(OnRebindControlBlurred);
            rebindControl.RegisterCallback<DetachFromPanelEvent>(OnRebindControlDetachedFromPanel);
            rebindControl.OnCancel += RebindControl_OnCancel;


            var rowElement = MakeRow(shortcutNameCell, bindingContainer);

            rowElement.RegisterCallback<MouseDownEvent>(OnMouseDownCategoryTable);
            rowElement.RegisterCallback<MouseUpEvent>(OnMouseUpCategoryTable);

            return rowElement;
        }

        void RebindControl_OnCancel()
        {
            EndRebind();
        }

        void OnRebindControlBlurred(BlurEvent evt)
        {
            var el = (VisualElement)evt.target;
            if (el.style.visibility == Visibility.Visible)
                EndRebind();
        }

        void OnRebindControlDetachedFromPanel(DetachFromPanelEvent evt)
        {
            EndRebind(false);
        }

        void BindShortcutEntryItem(VisualElement shortcutElementTemplate, int index)
        {
            var shortcutEntry = m_ViewController.GetShortcutList()[index];

            var nameElement = (TextElement)shortcutElementTemplate[0];
            var bindingContainer = shortcutElementTemplate[1];
            var bindingTextElement = bindingContainer.Query<TextElement>().First();
            var bindingField = bindingContainer.Query<ShortcutTextField>().First();

            nameElement.text = m_ViewController.GetShortcutPathList()[index];
            nameElement.tooltip = nameElement.text;
            bindingTextElement.text = KeyCombination.SequenceToString(shortcutEntry.combinations);
            bindingField.SetValueWithoutNotify(shortcutEntry.combinations.ToList());
            bindingField.RegisterValueChangedCallback(EditingShortcutEntryBindingChanged);

            if (shortcutEntry.overridden)
            {
                StyleUtility.StyleEntryOverriden(nameElement);
                StyleUtility.StyleEntryOverriden(bindingTextElement);
            }
            else
            {
                StyleUtility.StyleEntryNormal(nameElement);
                StyleUtility.StyleEntryNormal(bindingTextElement);
            }

            if (m_EditingBindings == shortcutEntry)
            {
                StyleUtility.StyleHidden(bindingTextElement);
                StyleUtility.StyleVisible(bindingField);
                bindingField.Focus();
            }
            else
            {
                StyleUtility.StyleVisible(bindingTextElement);
                StyleUtility.StyleHidden(bindingField);
            }
        }

        void EditingShortcutEntryBindingChanged(ChangeEvent<List<KeyCombination>> evt)
        {
            m_ViewController.RequestRebindOfSelectedEntry(evt.newValue);
            EndRebind();
        }

        static VisualElement MakeItemForCategoriesTable()
        {
            var element = new TextElement();
            StyleUtility.StyleTextRow(element);
            return element;
        }

        void BindCategoriesTableItem(VisualElement categoryElementTemplate, int index)
        {
            var elementTemplate = (TextElement)categoryElementTemplate;
            elementTemplate.text = m_ViewController.GetCategories()[index];
        }

        static VisualElement CreateVisualElement(string name)
        {
            var ve = new VisualElement();
            ve.name = name;
            return ve;
        }

        void CategorySelectionChanged(List<object> selection)
        {
            Assert.AreEqual(1, selection.Count);

            if (selection.Count == 0)
                m_ViewController.SetCategorySelected(null);
            else
                m_ViewController.SetCategorySelected((string)selection[0]);
        }

        static VisualElement MakeRow(VisualElement label, VisualElement content)
        {
            var row = new VisualElement();

            StyleUtility.StyleRow(row);

            StyleUtility.StyleFlexibleTableCell(label);
            StyleUtility.StyleFlexibleTableCell(content);
            StyleUtility.StyleTextRow(label);
            StyleUtility.StyleTextRow(content);

            row.Add(label);
            row.Add(content);
            return row;
        }

        void BuildSearchField(VisualElement root)
        {
            //TODO: Read from a uxml
            var searchControlContainer = CreateVisualElement("searchControlContainer");
            var searchOptionsDropDown = CreateVisualElement("searchOptionsDropDown");
            m_SearchTextField = new TextField();
            m_KeyBindingSearchField = new ShortcutTextField();
            m_SearchCancelEnding = CreateVisualElement("searchCancelEnding");

            ShowAppropriateSearchField();

            m_SearchTextField.value = m_ViewController.GetSearch();
            m_SearchTextField.RegisterValueChangedCallback(OnSearchStringChanged);

            m_SearchCancelEnding.RegisterCallback<MouseDownEvent>(CancelSearchClicked);

            searchOptionsDropDown.RegisterCallback<MouseDownEvent>(OnSearchOptionsClicked);

            m_KeyBindingSearchField.value = m_ViewController.GetBindingSearch();
            m_KeyBindingSearchField.OnWorkingValueChanged += SearchByBindingsChanged;

            StyleUtility.StyleSearchContainer(searchControlContainer);

            StyleUtility.StyleSearchDropdown(searchOptionsDropDown);

            StyleUtility.StyleSearchTextField(m_SearchTextField);
            StyleUtility.StyleSearchTextField(m_KeyBindingSearchField);

            StyleUtility.StyleSearchEnding(m_SearchCancelEnding);

            HandleClearButtonVisibility();

            searchOptionsDropDown.Add(m_SearchTextField);
            searchOptionsDropDown.Add(m_KeyBindingSearchField);
            searchControlContainer.Add(searchOptionsDropDown);
            searchControlContainer.Add(m_SearchCancelEnding);

            root.Add(searchControlContainer);
        }

        void RefreshProfiles()
        {
            m_ActiveProfileDropdownButton.text = m_ViewController.activeProfile;
        }

        void BuildProfileManagementRow(VisualElement header)
        {
            //TODO: Read from a uxml
            m_ActiveProfileDropdownButton = new TextElement();

            m_ActiveProfileDropdownButton.text = m_ViewController.activeProfile;
            StyleUtility.StyleActiveProfileDropdownButton(m_ActiveProfileDropdownButton);

            m_ActiveProfileDropdownButton.RegisterCallback<MouseDownEvent>(OnProfileContextMenuMouseDown);

            header.Add(m_ActiveProfileDropdownButton);
        }

        void OnCreateProfileClicked()
        {
            PromptWindow.Show(L10n.Tr("Create profile"),
                L10n.Tr("Create a shortcut profile"),
                L10n.Tr("Enter the name of the profile you want to create"),
                L10n.Tr("Profile Name:"),
                L10n.Tr("New profile"),
                L10n.Tr("Create"),
                m_ViewController.CanCreateProfile,
                m_ViewController.CreateProfile);
        }

        void OnRenameProfileClicked()
        {
            PromptWindow.Show(L10n.Tr("Rename profile"),
                L10n.Tr("Rename a shortcut profile"),
                string.Format(L10n.Tr("Enter the new name you want to give the profile '{0}'"), m_ViewController.activeProfile),
                L10n.Tr("Profile Name:"),
                m_ViewController.activeProfile,
                L10n.Tr("Rename"),
                m_ViewController.CanRenameActiveProfile,
                m_ViewController.RenameActiveProfile);
        }

        void OnDeleteProfileClicked()
        {
            m_ViewController.DeleteActiveProfile();
        }

        void OnActiveProfileChanged(ChangeEvent<string> evt)
        {
            m_ViewController.activeProfile = evt.newValue;
        }

        void OnActiveProfileChanged(string profile)
        {
            m_ViewController.activeProfile = profile;
        }

        void OnProfileContextMenuMouseDown(MouseDownEvent evt)
        {
            var targetElement = (VisualElement)evt.target;
            var genericMenu = new GenericMenu();

            foreach (var profile in m_ViewController.GetAvailableProfiles())
            {
                genericMenu.AddItem(new GUIContent(profile), false, () => OnActiveProfileChanged(profile));
            }

            genericMenu.AddSeparator("");

            genericMenu.AddItem(EditorGUIUtility.TrTextContent("Create new profile..."), false, OnCreateProfileClicked);

            if (m_ViewController.CanRenameActiveProfile())
                genericMenu.AddItem(EditorGUIUtility.TrTextContent("Rename profile..."), false, OnRenameProfileClicked);
            else
                genericMenu.AddDisabledItem(EditorGUIUtility.TrTextContent("Rename profile..."));

            if (m_ViewController.CanDeleteActiveProfile())
                genericMenu.AddItem(EditorGUIUtility.TrTextContent("Delete profile..."), false, OnDeleteProfileClicked);
            else
                genericMenu.AddDisabledItem(EditorGUIUtility.TrTextContent("Delete profile..."));

            genericMenu.DropDown(targetElement.worldBound);
        }

        void BuildLegendRow(VisualElement root)
        {
            //TODO: Read from a uxml
            var container = new VisualElement();

            var labels = new[] { L10n.Tr("Unassigned Key"), L10n.Tr("Assigned Key"), L10n.Tr("Global Key") };
            var styles = new Action<VisualElement>[] { StyleUtility.StyleNormal, StyleUtility.StyleBoundToContext, StyleUtility.StyleBoundGlobally };

            StyleUtility.StyleRow(container);

            for (int i = 0; i < labels.Length; i++)
            {
                var colorField = new VisualElement();
                var label = new TextElement() { text = labels[i] };
                StyleUtility.StyleKey(colorField);
                styles[i](colorField);
                StyleUtility.NormalTextElement(label);
                StyleUtility.StyleHeaderLabelColor(colorField);
                container.Add(colorField);
                container.Add(label);
            }

            root.Add(container);
        }

        void BuildShortcutTableSearchFilter(VisualElement root)
        {
            //TODO: Read from a uxml
            m_ShortcutsTableSearchFilterContainer = CreateVisualElement("shortcutsTableSearchFilterContainer");
            var searchLabel = new TextElement() { text = L10n.Tr("Search:") };
            m_SearchFiltersContainer = CreateVisualElement("searchFiltersContainer");

            StyleUtility.StyleRow(m_SearchFiltersContainer);

            StyleUtility.StyleTextRow(searchLabel);

            StyleUtility.StyleSearchFilterRow(m_ShortcutsTableSearchFilterContainer);

            m_ShortcutsTableSearchFilterContainer.Add(searchLabel);
            m_ShortcutsTableSearchFilterContainer.Add(m_SearchFiltersContainer);

            root.Add(m_ShortcutsTableSearchFilterContainer);
        }

        void UpdateShortcutTableSearchFilter()
        {
            if (!m_ViewController.ShouldShowSearchFilters())
            {
                StyleUtility.StyleHidden(m_ShortcutsTableSearchFilterContainer);
                return;
            }

            StyleUtility.StyleVisible(m_ShortcutsTableSearchFilterContainer);

            List<string> filters = new List<string>();
            m_ViewController.GetSearchFilters(filters);

            var selectedSearchFilter = m_ViewController.GetSelectedSearchFilter();

            m_SearchFiltersContainer.Clear();
            foreach (var filter in filters)
            {
                var filterElement = new TextElement() { text = filter };
                StyleUtility.NormalTextElement(filterElement);

                StyleUtility.StyleFilterElement(filterElement);

                if (selectedSearchFilter == filter)
                {
                    StyleUtility.StyleFilterElementSelected(filterElement);
                }
                filterElement.RegisterCallback<MouseDownEvent>(OnFilterElementClicked);
                m_SearchFiltersContainer.Add(filterElement);
            }
        }

        void OnFilterElementClicked(MouseDownEvent evt)
        {
            var filterElement = (TextElement)evt.target;
            m_ViewController.SetSelectedSearchFilter(filterElement.text);
        }

        void BuildVisualElementHierarchyRoot()
        {
            //TODO: Read from a uxml
            m_Root = new VisualElement();
            var header = new VisualElement();
            var spacer = new VisualElement();

            m_KeyboardElement = new Keyboard(m_BindingStateProvider, m_ViewController.GetSelectedKey(), m_ViewController.GetSelectedEventModifiers());
            m_KeyboardElement.DragPerformed += OnKeyboardKeyDragPerformed;
            m_KeyboardElement.CanDrop += CanEntryBeAssignedToKey;
            //m_KeyboardElement.KeySelectedAction += KeySelected;
            m_KeyboardElement.TooltipProvider += GetToolTipForKey;
            m_KeyboardElement.ContextMenuProvider += GetContextMenuForKey;


            var searchRowContainer = CreateVisualElement("searchRowContainer");

            var shortcutEntriesContainer = CreateVisualElement("shortcutEntriesContainer");
            var categoryContainer = CreateVisualElement("categoryContainer");
            var categoryHeader = new TextElement() { name = "shortcutsTableHeaderName", text = L10n.Tr("Category") };
            m_CategoryTreeView = new ListView((IList)m_ViewController.GetCategories(), k_ListItemHeight, MakeItemForCategoriesTable, BindCategoriesTableItem) { name = "categoryTreeView" };
            var shortcutsTableContainer = CreateVisualElement("shortcutsTableContainer");
            var shortcutsTableHeader = CreateVisualElement("shortcutsTableHeader");
            var shortcutsTableHeaderName = new TextElement() { text = L10n.Tr("Command"), name = "shortcutsTableHeaderName" };
            var shortcutsTableResizeHandle = CreateVisualElement("shortcutResizeHandle");
            var shortcutsTableHeaderBindings = new TextElement() { text = L10n.Tr("Shortcuts"), name = "shortcutsTableHeaderBindings" };
            m_ShortcutsTable = new ListView((IList)m_ViewController.GetShortcutList(), k_ListItemHeight, MakeItemForShortcutTable, BindShortcutEntryItem) { name = "shortcutsTable" };

            m_CategoryTreeView.selectedIndex = m_ViewController.selectedCategoryIndex;
            m_CategoryTreeView.onSelectionChanged += CategorySelectionChanged;

            m_ShortcutsTable.Q<ScrollView>().showVertical = true;
            m_ShortcutsTable.onSelectionChanged += ShortcutSelectionChanged;
            m_ShortcutsTable.onItemChosen += ShortcutTableEntryChosen;
            m_ShortcutsTable.RegisterCallback<MouseUpEvent>(ShortcutTableRightClick);
            m_ShortcutsTable.RegisterCallback<GeometryChangedEvent>(ShortcutTableGeometryChanged);

            StyleUtility.NormalTextColor(shortcutsTableHeaderName);
            StyleUtility.NormalTextColor(shortcutsTableHeaderBindings);
            StyleUtility.StyleResizeHandle(shortcutsTableResizeHandle);
            StyleUtility.NormalTextColor(categoryHeader);

            StyleUtility.StyleRootPanel(m_Root);
            StyleUtility.StyleFlexibleElement(spacer);
            StyleUtility.StyleRow(header);

            StyleUtility.StyleReverseRowDirection(searchRowContainer);

            StyleUtility.StyleShortcutEntriesContainer(shortcutEntriesContainer);

            StyleUtility.StyleCategoryContainer(categoryContainer);
            StyleUtility.StyleHeaderCell(categoryHeader);
            StyleUtility.StyleHeaderText(categoryHeader);
            StyleUtility.StyleFlexibleElement(m_CategoryTreeView);

            StyleUtility.StyleShortcutEntryTable(shortcutsTableContainer);

            StyleUtility.StyleRow(shortcutsTableHeader);
            StyleUtility.StyleHeaderCell(shortcutsTableHeader);

            StyleUtility.StyleFlexibleTableCell(shortcutsTableHeaderName);
            StyleUtility.StyleFlexibleTableCell(shortcutsTableHeaderBindings);
            StyleUtility.StyleHeaderText(shortcutsTableHeaderName);
            StyleUtility.StyleHeaderText(shortcutsTableHeaderBindings);

            StyleUtility.StyleFlexibleElement(m_ShortcutsTable);

            m_HorizontalColumnDragger = new HorizontalColumnDragger(75, m_ShortcutsTable);
            shortcutsTableResizeHandle.AddManipulator(m_HorizontalColumnDragger);
            shortcutsTableHeaderName.pickingMode = PickingMode.Ignore;
            shortcutsTableHeaderBindings.pickingMode = PickingMode.Ignore;

            BuildProfileManagementRow(header);
            header.Add(spacer);
            BuildLegendRow(header);

            BuildSearchField(searchRowContainer);

            shortcutsTableHeader.Add(shortcutsTableHeaderName);
            shortcutsTableHeader.Add(shortcutsTableHeaderBindings);
            shortcutsTableHeader.Add(shortcutsTableResizeHandle);

            shortcutsTableContainer.Add(shortcutsTableHeader);
            BuildShortcutTableSearchFilter(shortcutsTableContainer);
            shortcutsTableContainer.Add(m_ShortcutsTable);

            categoryContainer.Add(categoryHeader);
            categoryContainer.Add(m_CategoryTreeView);
            shortcutEntriesContainer.Add(categoryContainer);
            shortcutEntriesContainer.Add(shortcutsTableContainer);

            m_Root.Add(header);
            m_Root.Add(m_KeyboardElement);
            m_Root.Add(searchRowContainer);
            m_Root.Add(shortcutEntriesContainer);
        }

        GenericMenu GetContextMenuForEntries(IEnumerable<ShortcutEntry> entries)
        {
            if (entries == null || !entries.Any())
                return null;

            var menu = new GenericMenu();

            foreach (var entry in entries)
            {
                // Change / to : here to avoid deep submenu nesting
                var mangledPath = $"{entry.identifier.path.Replace('/', ':')} ({entry.combinations.FirstOrDefault()})";
                if (entry.overridden)
                    menu.AddItem(new GUIContent($"{mangledPath}/{L10n.Tr("Reset to default")}"), false, ResetToDefault, entry);
                else
                    menu.AddDisabledItem(new GUIContent($"{mangledPath}/{L10n.Tr("Reset to default")}"));
                menu.AddItem(new GUIContent($"{mangledPath}/{L10n.Tr("Remove shortcut")}"), false, RemoveShortcut, entry);
            }

            return menu;
        }

        private GenericMenu GetContextMenuForKey(KeyCode keyCode, EventModifiers modifiers)
        {
            return GetContextMenuForEntries(m_ViewController.GetShortcutsBoundTo(keyCode, modifiers));
        }

        private void ResetToDefault(object entryObject)
        {
            (entryObject as ShortcutEntry)?.ResetToDefault();
            RefreshShortcutList();
        }

        private void RemoveShortcut(object entryObject)
        {
            (entryObject as ShortcutEntry)?.SetOverride(new List<KeyCombination>());
            RefreshShortcutList();
        }

        string GetToolTipForKey(KeyCode keyCode, EventModifiers modifiers)
        {
            var entries = m_ViewController.GetShortcutsBoundTo(keyCode, modifiers);
            if (entries == null || entries.Count == 0)
                return null;

            var builder = new StringBuilder();
            foreach (var entry in entries)
            {
                builder.AppendLine(entry.identifier.path);
            }

            builder.TrimLastLine();

            return builder.ToString();
        }

        void ShortcutTableEntryChosen(object obj)
        {
            var entry = (ShortcutEntry)obj;
            var row = m_ShortcutsTable.Query<VisualElement>().Checked().First();
            StartRebind(entry, row);
        }

        void StartRebind(ShortcutEntry entry, VisualElement row)
        {
            m_EditingBindings = entry;

            if (row != null)
            {
                var bindingInput = row.Query<ShortcutTextField>().First();
                var textElement = bindingInput.parent.Query<TextElement>().First();
                StyleUtility.StyleVisible(bindingInput);
                StyleUtility.StyleHidden(textElement);
                bindingInput.Focus();
            }
        }

        void EndRebind(bool refresh = true)
        {
            if (m_EditingBindings == null)
                return;

            m_EditingBindings = null;
            //TODO: this refresh causes issues when trying to double click another binding, while a binding is being edited.
            if (refresh)
                m_ShortcutsTable.Refresh();
        }

        void OnSearchStringChanged(ChangeEvent<string> evt)
        {
            m_ViewController.SetSearch(evt.newValue);
            HandleClearButtonVisibility();
        }

        void SearchByBindingsChanged(List<KeyCombination> newBindingSearch)
        {
            m_ViewController.SetBindingSearch(newBindingSearch);
            HandleClearButtonVisibility();
        }

        void HandleClearButtonVisibility()
        {
            var shouldShow = false;
            switch (m_ViewController.searchMode)
            {
                case SearchOption.Name:
                    shouldShow = !string.IsNullOrEmpty(m_ViewController.GetSearch());
                    break;
                case SearchOption.Binding:
                    shouldShow = m_ViewController.GetBindingSearch().Any();
                    break;
            }
            if (shouldShow)
            {
                StyleUtility.StyleSearchEndingCancelButtonVisible(m_SearchCancelEnding);
            }
            else
            {
                StyleUtility.StyleSearchEnding(m_SearchCancelEnding);
            }
        }

        void CancelSearchClicked(MouseDownEvent evt)
        {
            m_SearchTextField.value = "";
            m_KeyBindingSearchField.value = new List<KeyCombination>();
        }

        void OnSearchOptionsClicked(MouseDownEvent evt)
        {
            var targetElement = (VisualElement)evt.target;
            var menu = new GenericMenu();
            menu.AddItem(EditorGUIUtility.TrTextContent("Command"), m_ViewController.searchMode == SearchOption.Name, SearchOptionSelected, SearchOption.Name);
            menu.AddItem(EditorGUIUtility.TrTextContent("Shortcut"), m_ViewController.searchMode == SearchOption.Binding, SearchOptionSelected, SearchOption.Binding);
            var menuPosition = new Vector2(0.0f, targetElement.layout.height);
            menuPosition = targetElement.LocalToWorld(menuPosition);
            var menuRect = new Rect(menuPosition, Vector2.zero);
            menu.DropDown(menuRect);
        }

        void SearchOptionSelected(object searchOptionArg)
        {
            var newValue = (SearchOption)searchOptionArg;
            if (m_ViewController.searchMode != newValue)
            {
                m_ViewController.searchMode = newValue;
                m_SearchTextField.value = "";
                m_KeyBindingSearchField.value = new List<KeyCombination>();
                ShowAppropriateSearchField();
            }
        }

        void ShowAppropriateSearchField()
        {
            switch (m_ViewController.searchMode)
            {
                case SearchOption.Name:
                    StyleUtility.StyleVisible(m_SearchTextField);
                    StyleUtility.StyleHidden(m_KeyBindingSearchField);
                    break;
                case SearchOption.Binding:
                    StyleUtility.StyleHidden(m_SearchTextField);
                    StyleUtility.StyleVisible(m_KeyBindingSearchField);
                    break;
            }
        }

        void ShortcutSelectionChanged(List<object> selection)
        {
            if (selection.Count > 0)
            {
                var newSelection = (ShortcutEntry)selection[0];
                if (newSelection != m_ViewController.selectedEntry)
                {
                    m_ViewController.ShortcutEntrySelected(newSelection);
                    EndRebind();
                }
            }
        }

        void ShortcutTableRightClick(MouseUpEvent evt)
        {
            if (evt.button != 1 || m_ViewController.selectedEntry == null)
                return;
            GenericMenu menu = GetContextMenuForEntries(new[] { m_ViewController.selectedEntry });
            menu.ShowAsContext();
        }

        void ShortcutTableGeometryChanged(GeometryChangedEvent evt)
        {
            m_HorizontalColumnDragger.UpdatePositions();
            m_ShortcutsTable.UnregisterCallback<GeometryChangedEvent>(ShortcutTableGeometryChanged);
        }

        bool CanEntryBeAssignedToKey(KeyCode keyCode, EventModifiers eventModifier, ShortcutEntry entry)
        {
            return m_ViewController.CanEntryBeAssignedToKey(keyCode, eventModifier, entry);
        }

        void OnKeyboardKeyDragPerformed(KeyCode keyCode, EventModifiers eventModifier, ShortcutEntry entry)
        {
            m_ViewController.DragEntryAndDropIntoKey(keyCode, eventModifier, entry);
        }

        void OnMouseDownCategoryTable(MouseDownEvent evt)
        {
            m_MouseDownStartPos = evt.localMousePosition;
            m_StartedDrag = false;
            var visualElement = ((VisualElement)evt.currentTarget);


            visualElement.RegisterCallback<MouseMoveEvent>(OnMouseMoveCategoryTable);
            visualElement.RegisterCallback<MouseLeaveEvent>(OnMouseLeaveWhileButtonDownCategoryTable);
        }

        void OnMouseLeaveWhileButtonDownCategoryTable(MouseLeaveEvent evt)
        {
            StartDrag((VisualElement)evt.currentTarget);
        }

        void OnMouseUpCategoryTable(MouseUpEvent evt)
        {
            m_StartedDrag = false;
            m_MouseDownStartPos = Vector2.zero;
            var visualElement = ((VisualElement)evt.currentTarget);
            visualElement.UnregisterCallback<MouseMoveEvent>(OnMouseMoveCategoryTable);
            visualElement.UnregisterCallback<MouseLeaveEvent>(OnMouseLeaveWhileButtonDownCategoryTable);
        }

        void OnMouseMoveCategoryTable(MouseMoveEvent evt)
        {
            if ((m_MouseDownStartPos - evt.localMousePosition).sqrMagnitude > 9.0)
            {
                StartDrag((VisualElement)evt.currentTarget);
            }
        }

        void StartDrag(VisualElement target)
        {
            if (m_StartedDrag)
                return;

            target.UnregisterCallback<MouseMoveEvent>(OnMouseMoveCategoryTable);
            target.UnregisterCallback<MouseLeaveEvent>(OnMouseLeaveWhileButtonDownCategoryTable);
            m_StartedDrag = true;
            DragAndDrop.activeControlID = target.GetHashCode(); //TODO: how to handle activeControlID in UIELements
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.SetGenericData("ShortcutCommandItem", m_ViewController.GetShortcutList()[m_ShortcutsTable.selectedIndex]);
            DragAndDrop.StartDrag("Assign command to key");
        }
    }

    class Key : TextElement
    {
        public KeyCode key;

        public Key(KeyCode k, string displayName)
        {
            key = k;
            name = k.ToString();
            text = displayName;

            StyleUtility.StyleKey(this);
        }
    }

    class Keyboard : VisualElement
    {
        struct KeyDef
        {
            public KeyCode keycode;
            public string displayName;

            public KeyDef(KeyCode kc)
            {
                keycode = kc;
                displayName = kc.ToString();
            }

            public KeyDef(KeyCode kc, string name)
            {
                keycode = kc;
                displayName = name;
            }
        }

        EventModifiers m_CurrentModifiers;
        Key m_SelectedKey;

        [NonSerialized]
        Dictionary<EventModifiers, List<Key>> m_ModifierKeys = new Dictionary<EventModifiers, List<Key>>();

        [NonSerialized]
        List<Key> m_AllKeys = new List<Key>();

        IKeyBindingStateProvider m_KeyBindingStateProvider;

        internal event Action<KeyCode, EventModifiers> KeySelectedAction;
        internal event Action<KeyCode, EventModifiers, ShortcutEntry> DragPerformed;
        internal event Func<KeyCode, EventModifiers, ShortcutEntry, bool> CanDrop;
        internal event Func<KeyCode, EventModifiers, string> TooltipProvider;
        internal event Func<KeyCode, EventModifiers, GenericMenu> ContextMenuProvider;


        public Keyboard(IKeyBindingStateProvider keyBindingStateProvider, KeyCode initiallySelectedKey = KeyCode.None, EventModifiers initiallyActiveModifiers = EventModifiers.None)
        {
            m_KeyBindingStateProvider = keyBindingStateProvider;
            KeyDef[] bottomRow;

            if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
            {
                bottomRow = new[]
                {
                    new KeyDef(KeyCode.LeftAlt, "Option"),
                    new KeyDef(KeyCode.LeftCommand, "Command"),
                    new KeyDef(KeyCode.Space),
                    new KeyDef(KeyCode.RightCommand, "Command"),
                    new KeyDef(KeyCode.RightAlt, "Option"),
                };
            }
            else
            {
                bottomRow = new[]
                {
                    new KeyDef(KeyCode.LeftControl, "Control"),
                    new KeyDef(KeyCode.LeftAlt, "Alt"),
                    new KeyDef(KeyCode.Space),
                    new KeyDef(KeyCode.RightAlt, "Alt"),
                    new KeyDef(KeyCode.RightControl, "Control"),
                };
            }

            var keysList = new List<KeyDef[]>
            {
                new[]
                {
                    new KeyDef(KeyCode.Escape, "Esc"),
                    new KeyDef(KeyCode.None),
                    new KeyDef(KeyCode.F1),
                    new KeyDef(KeyCode.F2),
                    new KeyDef(KeyCode.F3),
                    new KeyDef(KeyCode.F4),
                    new KeyDef(KeyCode.None),
                    new KeyDef(KeyCode.F5),
                    new KeyDef(KeyCode.F6),
                    new KeyDef(KeyCode.F7),
                    new KeyDef(KeyCode.F8),
                    new KeyDef(KeyCode.None),
                    new KeyDef(KeyCode.F9),
                    new KeyDef(KeyCode.F10),
                    new KeyDef(KeyCode.F11),
                    new KeyDef(KeyCode.F12)
                },
                new[]
                {
                    new KeyDef(KeyCode.BackQuote, "`"),
                    new KeyDef(KeyCode.Alpha1, "1"),
                    new KeyDef(KeyCode.Alpha2, "2"),
                    new KeyDef(KeyCode.Alpha3, "3"),
                    new KeyDef(KeyCode.Alpha4, "4"),
                    new KeyDef(KeyCode.Alpha5, "5"),
                    new KeyDef(KeyCode.Alpha6, "6"),
                    new KeyDef(KeyCode.Alpha7, "7"),
                    new KeyDef(KeyCode.Alpha8, "8"),
                    new KeyDef(KeyCode.Alpha9, "9"),
                    new KeyDef(KeyCode.Alpha0, "0"),
                    new KeyDef(KeyCode.Minus, "-"),
                    new KeyDef(KeyCode.Equals, "="),
                    new KeyDef(KeyCode.Backspace, "←")
                },
                new[]
                {
                    new KeyDef(KeyCode.Tab),
                    new KeyDef(KeyCode.Q),
                    new KeyDef(KeyCode.W),
                    new KeyDef(KeyCode.E),
                    new KeyDef(KeyCode.R),
                    new KeyDef(KeyCode.T),
                    new KeyDef(KeyCode.Y),
                    new KeyDef(KeyCode.U),
                    new KeyDef(KeyCode.I),
                    new KeyDef(KeyCode.O),
                    new KeyDef(KeyCode.P),
                    new KeyDef(KeyCode.LeftBracket, "["),
                    new KeyDef(KeyCode.RightBracket, "]"),
                    new KeyDef(KeyCode.Slash, "\\")
                },
                new[]
                {
                    new KeyDef(KeyCode.CapsLock, "Caps Lock"),
                    new KeyDef(KeyCode.A),
                    new KeyDef(KeyCode.S),
                    new KeyDef(KeyCode.D),
                    new KeyDef(KeyCode.F),
                    new KeyDef(KeyCode.G),
                    new KeyDef(KeyCode.H),
                    new KeyDef(KeyCode.J),
                    new KeyDef(KeyCode.K),
                    new KeyDef(KeyCode.L),
                    new KeyDef(KeyCode.Semicolon, ";"),
                    new KeyDef(KeyCode.Quote, "'"),
                    new KeyDef(KeyCode.Return),
                },
                new[]
                {
                    new KeyDef(KeyCode.LeftShift, "Shift"),
                    new KeyDef(KeyCode.Z),
                    new KeyDef(KeyCode.X),
                    new KeyDef(KeyCode.C),
                    new KeyDef(KeyCode.V),
                    new KeyDef(KeyCode.B),
                    new KeyDef(KeyCode.N),
                    new KeyDef(KeyCode.M),
                    new KeyDef(KeyCode.Comma, ","),
                    new KeyDef(KeyCode.Period, "."),
                    new KeyDef(KeyCode.Backslash, "/"),
                    new KeyDef(KeyCode.RightShift, "Shift"),
                },
                bottomRow,
            };

            var cursorControlKeysList = new List<KeyDef[]>()
            {
                new[]
                {
                    new KeyDef(KeyCode.F13),
                    new KeyDef(KeyCode.F14),
                    new KeyDef(KeyCode.F15)
                },
                new[]
                {
                    new KeyDef(KeyCode.Insert, "Ins"),
                    new KeyDef(KeyCode.Home, "Hom"),
                    new KeyDef(KeyCode.PageUp, "Pg Up")
                },
                new[]
                {
                    new KeyDef(KeyCode.Delete, "Del"),
                    new KeyDef(KeyCode.End),
                    new KeyDef(KeyCode.PageDown, "Pg Dn")
                },
                new[]
                {
                    new KeyDef(KeyCode.None),
                },
                new[]
                {
                    new KeyDef(KeyCode.None),
                    new KeyDef(KeyCode.UpArrow, "▲"),
                    new KeyDef(KeyCode.None),
                },
                new[]
                {
                    new KeyDef(KeyCode.LeftArrow, "◀"),
                    new KeyDef(KeyCode.DownArrow, "▼"),
                    new KeyDef(KeyCode.RightArrow, "▶"),
                }
            };

            var dictionaryKeyStyle = new Dictionary<KeyCode, Action<Key>>()
            {
                {KeyCode.Backspace, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.Tab, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.Slash, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.CapsLock, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.Return, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.LeftShift, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.RightShift, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.LeftControl, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.LeftWindows, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.LeftCommand, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.LeftAlt, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.Space, StyleUtility.StyleSpace},
                {KeyCode.RightAlt, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.RightWindows, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.RightControl, StyleUtility.StyleKeyFlexibleWidth},
                {KeyCode.RightCommand, StyleUtility.StyleKeyFlexibleWidth},
            };

            var mainContainer = new VisualElement() { name = "fullKeyboardContainer" };

            var compactContainer = new VisualElement() { name = "compactKeyboardContainer" };
            var cursorControlContainer = new VisualElement() { name = "cursorControlKeyboardContainer" };

            BuildKeyboardVisualTree(keysList, dictionaryKeyStyle, compactContainer);

            BuildKeyboardVisualTree(cursorControlKeysList, dictionaryKeyStyle, cursorControlContainer);

            compactContainer.style.width = (keysList[0].Length) * StyleUtility.k_KeySize;
            StyleUtility.StyleCompactContainer(compactContainer);

            StyleUtility.StyleKeyboardElement(this);

            focusable = true;
            tabIndex = 0;

            StyleUtility.StyleRow(mainContainer);

            mainContainer.Add(compactContainer);
            mainContainer.Add(cursorControlContainer);

            Add(mainContainer);

            m_CurrentModifiers = initiallyActiveModifiers;
            var keyElement = m_AllKeys.Find(el => el.key == initiallySelectedKey);
            m_SelectedKey = keyElement;

            mainContainer.RegisterCallback<MouseDownEvent>(OnMouseDown);
            RegisterCallback<KeyDownEvent>(OnKeyDown);
            RegisterCallback<KeyUpEvent>(OnKeyUp);
            RegisterCallback<ExecuteCommandEvent>(HandleModifierKeysCommand);
            RegisterCallback<ValidateCommandEvent>(HandleModifierKeysCommand);
            //RegisterCallback<MouseOverEvent>(OnMouseOver);
            //RegisterCallback<MouseOutEvent>(OnMouseOut);

            RegisterCallback<DragEnterEvent>(OnDragEnter);
            RegisterCallback<DragUpdatedEvent>(OnDragUpdated);
            RegisterCallback<DragPerformEvent>(OnDragPerfom);

            RegisterCallback<TooltipEvent>(OnTooltip);

            RefreshKeyboardBoundVisuals();
        }

        void HandleModifierKeysCommand<T>(CommandEventBase<T> evt) where T : CommandEventBase<T>, new()
        {
            if (evt.commandName == EventCommandNames.ModifierKeysChanged)
            {
                SetModifiers(evt.imguiEvent.modifiers);
                evt.StopPropagation();
            }
        }

        void OnTooltip(TooltipEvent evt)
        {
            if (TooltipProvider == null)
                return;

            var keyElement = evt.target as Key;
            if (keyElement == null)
                return;

            evt.rect = keyElement.worldBound;
            evt.tooltip = TooltipProvider(keyElement.key, m_CurrentModifiers);
        }

        void OnDragEnter(DragEnterEvent evt)
        {
            DoDragUpdate(evt.target);
        }

        void OnDragUpdated(DragUpdatedEvent evt)
        {
            DoDragUpdate(evt.target);
        }

        void DoDragUpdate(IEventHandler target)
        {
            var keyElement = target as Key;
            if (keyElement == null)
                return;

            var shortcutEntry = (ShortcutEntry)DragAndDrop.GetGenericData("ShortcutCommandItem");
            if (shortcutEntry == null)
                return;

            if (CanDrop != null && CanDrop(keyElement.key, m_CurrentModifiers, shortcutEntry))
                DragAndDrop.visualMode = DragAndDropVisualMode.Link;
        }

        void OnDragPerfom(DragPerformEvent evt)
        {
            var keyElement = (Key)evt.target;
            var shortcutEntry = (ShortcutEntry)DragAndDrop.GetGenericData("ShortcutCommandItem");
            if (DragPerformed != null)
                DragPerformed(keyElement.key, m_CurrentModifiers, shortcutEntry);
        }

        void BuildKeyboardVisualTree(List<KeyDef[]> keysList, Dictionary<KeyCode, Action<Key>> dictionaryKeyStyle, VisualElement container)
        {
            foreach (var rowKey in keysList)
            {
                var keyRow = new VisualElement();

                foreach (var keyDef in rowKey)
                {
                    if (keyDef.keycode != KeyCode.None)
                    {
                        var keyElement = new Key(keyDef.keycode, keyDef.displayName);
                        StyleUtility.StyleVerticalKeySizing(keyElement);
                        StyleUtility.NormalTextColor(keyElement);

                        Action<Key> keyStyler;
                        if (dictionaryKeyStyle.TryGetValue(keyDef.keycode, out keyStyler))
                        {
                            keyStyler(keyElement);
                        }

                        if (m_KeyBindingStateProvider.IsModifier(keyDef.keycode))
                        {
                            EventModifiers modifier = m_KeyBindingStateProvider.ModifierFromKeyCode(keyDef.keycode);
                            List<Key> keyList;
                            if (!m_ModifierKeys.TryGetValue(modifier, out keyList))
                            {
                                keyList = new List<Key>(2);
                                m_ModifierKeys.Add(modifier, keyList);
                            }
                            keyList.Add(keyElement);
                            StyleUtility.StyleModifier(keyElement);
                        }

                        if (m_KeyBindingStateProvider.IsReservedKey(keyDef.keycode))
                        {
                            StyleUtility.StyleSystemReserved(keyElement);
                        }

                        keyRow.Add(keyElement);
                        m_AllKeys.Add(keyElement);
                    }
                    else
                    {
                        var spacer = new VisualElement();
                        StyleUtility.StyleKeyFlexibleWidth(spacer);
                        keyRow.Add(spacer);
                    }
                }

                container.Add(keyRow);
            }

            StyleUtility.StyleKeyboardFirstRow(container.Children().First());


            foreach (var child in container.Children())
            {
                StyleUtility.StyleRow(child);
            }
        }

        void RefreshKeyboardBoundVisuals()
        {
            foreach (var key in m_AllKeys)
            {
                StyleKey(key);
            }
        }

        void StyleKey(Key key)
        {
            if (!m_KeyBindingStateProvider.CanBeSelected(key.key))
                return;

            var bindingState = m_KeyBindingStateProvider.GetBindingStateForKeyWithModifiers(key.key, m_CurrentModifiers);

            StyleUtility.StyleNormal(key);

            if (m_SelectedKey == key)
                StyleUtility.StyleSelected(key);

            if (bindingState == BindingState.BoundGlobally)
                StyleUtility.StyleBoundGlobally(key);
            else if (bindingState == BindingState.BoundToContext)
                StyleUtility.StyleBoundToContext(key);
        }

        void OnKeyDown(KeyDownEvent evt)
        {
            SetModifiers(evt.modifiers);
            evt.StopPropagation();
        }

        void OnKeyUp(KeyUpEvent evt)
        {
            SetModifiers(evt.modifiers);
            evt.StopPropagation();
        }

        void SetModifiers(EventModifiers modifiers)
        {
            if (modifiers == m_CurrentModifiers)
                return;

            m_CurrentModifiers = modifiers;

            foreach (var modifierPair in m_ModifierKeys)
            {
                var modifierPressed = (m_CurrentModifiers & modifierPair.Key) == modifierPair.Key;
                foreach (var modifierKey in modifierPair.Value)
                {
                    if (modifierPressed)
                        StyleUtility.StyleModifierActive(modifierKey);
                    else
                        StyleUtility.StyleModifier(modifierKey);
                }
            }

            RefreshKeyboardBoundVisuals();
            var selectedKey = m_SelectedKey != null ? m_SelectedKey.key : KeyCode.None;
            KeySelectedAction?.Invoke(selectedKey, m_CurrentModifiers);
        }

        void OnMouseDown(MouseDownEvent evt)
        {
            panel.focusController.SwitchFocus(this);
            var keyElement = evt.target as Key;
            if (keyElement != null)
            {
                switch (evt.button)
                {
                    case 0:
                        SetKeySelected(keyElement);
                        break;
                    case 1:
                        var menu = ContextMenuProvider?.Invoke(keyElement.key, m_CurrentModifiers);
                        menu?.DropDown(keyElement.worldBound);
                        break;
                    default:
                        break;
                }
            }
        }

        void SetKeySelected(Key keyElement)
        {
            if (!m_KeyBindingStateProvider.CanBeSelected(keyElement.key))
            {
                EventModifiers modifier = m_KeyBindingStateProvider.ModifierFromKeyCode(keyElement.key);
                if (modifier != EventModifiers.None)
                {
                    var newModifiers = m_CurrentModifiers ^ modifier;
                    SetModifiers(newModifiers);
                }

                return;
            }

            if (KeySelectedAction == null)
                return;

            var prevSelectedKey = m_SelectedKey;
            m_SelectedKey = keyElement;

            if (prevSelectedKey != null)
            {
                StyleKey(prevSelectedKey);
            }

            KeySelectedAction(m_SelectedKey.key, m_CurrentModifiers);
            StyleUtility.StyleSelected(m_SelectedKey);
        }

        void OnMouseOut(MouseOutEvent evt)
        {
            var keyElement = evt.target as Key;
            if (keyElement == null)
                return;
            StyleKey(keyElement);
        }

        void OnMouseOver(MouseOverEvent evt)
        {
            var keyElement = evt.target as Key;
            if (keyElement == null)
                return;

            if (m_SelectedKey == keyElement)
                return;

            if (m_KeyBindingStateProvider.CanBeSelected(keyElement.key))
                StyleUtility.StyleHover(keyElement);
        }

        public void Refresh()
        {
            RefreshKeyboardBoundVisuals();
        }
    }

    class ShortcutTextField : TextInputBaseField<List<KeyCombination>>
    {
        List<KeyCombination> m_WorkingValue = new List<KeyCombination>();
        public VisualElement input => textInputBase;
        public List<KeyCombination> WorkingValue => m_WorkingValue;

        public event Action<List<KeyCombination>> OnWorkingValueChanged;
        public event Action OnCancel;

        const int maxChordLength = 1;
        HashSet<KeyCode> m_KeyDown = new HashSet<KeyCode>();

        private class ShortcutInput : TextInputBase
        {
            public override bool isPasswordField => false;
        }

        public ShortcutTextField() : base(kMaxLengthNone, char.MinValue, new ShortcutInput())
        {
            rawValue = new List<KeyCombination>();

            RegisterEvents(visualInput);
        }

        private void RegisterEvents(VisualElement input)
        {
            input.RegisterCallback<KeyDownEvent>(OnKeyDown);
            input.RegisterCallback<KeyUpEvent>(OnKeyUp);
            input.RegisterCallback<FocusEvent>((evt) => {
                StartNewCombination();
                evt.StopPropagation();
                textInputBase.editorEngine.MoveTextEnd();
            });
            input.RegisterCallback<BlurEvent>((evt) =>
            {
                Apply();
                evt.StopPropagation();
                textInputBase.editorEngine.MoveTextEnd();
            });
        }

        void OnKeyDown(KeyDownEvent kde)
        {
            if (kde.keyCode != KeyCode.None)
            {
                if (!m_KeyDown.Contains(kde.keyCode))
                {
                    //TODO: call ShortcutManagerWindowViewController.IsModifier instead
                    m_KeyDown.Add(kde.keyCode);

                    if (kde.keyCode == KeyCode.Escape)
                    {
                        Revert();
                        OnCancel?.Invoke();
                        kde.StopPropagation();
                    }
                    else if (kde.keyCode == KeyCode.Return)
                    {
                        Apply();
                        kde.StopPropagation();
                    }
                    else if (!ShortcutManagerWindowViewController.IsModifier(kde.keyCode))
                    {
                        AppendKeyCombination(kde.keyCode, kde.modifiers);
                        if (WorkingValue.Count == maxChordLength)
                        {
                            Apply();
                        }
                        kde.StopPropagation();
                    }
                }
            }
            textInputBase.editorEngine.MoveTextEnd();
        }

        void OnKeyUp(KeyUpEvent kue)
        {
            m_KeyDown.Remove(kue.keyCode);
            kue.StopPropagation();
            textInputBase.editorEngine.MoveTextEnd();
        }

        void InvokeWorkingValueChanged()
        {
            OnWorkingValueChanged?.Invoke(m_WorkingValue);
        }

        void AppendKeyCombination(KeyCode keyCode, EventModifiers modifiers)
        {
            m_WorkingValue.Add(KeyCombination.FromKeyboardInput(keyCode, modifiers));
            text = KeyCombination.SequenceToString(m_WorkingValue);
            InvokeWorkingValueChanged();
        }

        void StartNewCombination()
        {
            m_WorkingValue.Clear();
            text = "";
            InvokeWorkingValueChanged();
        }

        void Apply()
        {
            value = m_WorkingValue;
            if (hasFocus)
                focusController.SwitchFocus(null);
        }

        void Revert()
        {
            RevertWithoutNotify();
            InvokeWorkingValueChanged();
        }

        public void RevertWithoutNotify()
        {
            m_WorkingValue.Clear();
            m_WorkingValue.AddRange(value);
            text = KeyCombination.SequenceToString(m_WorkingValue);
        }

        public override void SetValueWithoutNotify(List<KeyCombination> newValue)
        {
            if (!ReferenceEquals(rawValue, newValue))
            {
                rawValue.Clear();
                if (newValue != null)
                    rawValue.AddRange(newValue);
            }

            text = KeyCombination.SequenceToString(rawValue);
            RevertWithoutNotify();


            if (!string.IsNullOrEmpty(viewDataKey))
                SaveViewData();
            MarkDirtyRepaint();
        }
    }

    internal class HorizontalColumnDragger : MouseManipulator
    {
        const string k_ShortcutmanagerColumnposition = "ShortcutManager_ColumnPosition";
        Vector2 m_Start;
        bool m_Active;
        float m_ClampPositionPadding;
        ListView m_Elements;
        float m_TargetPosition;

        public HorizontalColumnDragger(float clampPositionPadding, ListView elements)
        {
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
            m_Active = false;

            // TODO: Replace this with the maximum text width of the left and right TextElements
            m_ClampPositionPadding = clampPositionPadding;
            m_Elements = elements;
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<MouseDownEvent>(OnMouseDown);
            target.RegisterCallback<MouseUpEvent>(OnMouseUp);
            target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
            target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
            target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
        }

        void OnMouseDown(MouseDownEvent e)
        {
            if (m_Active)
            {
                e.StopImmediatePropagation();
                return;
            }

            if (CanStartManipulation(e))
            {
                m_Start = e.localMousePosition;
                m_Active = true;
                target.CaptureMouse();
                e.StopPropagation();
            }
        }

        void PersistHandlePosition()
        {
            EditorPrefs.SetFloat(k_ShortcutmanagerColumnposition, m_TargetPosition);
        }

        public void UpdatePositions()
        {
            if (m_TargetPosition == 0)
            {
                m_TargetPosition = EditorPrefs.GetFloat(k_ShortcutmanagerColumnposition, target.parent.layout.width / 2);
            }
            UpdateElements(m_TargetPosition);
        }

        void OnMouseMove(MouseMoveEvent e)
        {
            if (!m_Active || !target.HasMouseCapture())
                return;

            Vector2 diff = e.localMousePosition - m_Start;

            m_TargetPosition = target.layout.x + diff.x;
            m_TargetPosition = Mathf.Clamp(m_TargetPosition, m_ClampPositionPadding, target.parent.layout.width - m_ClampPositionPadding - target.style.width.value.value);

            UpdateElements(m_TargetPosition);

            e.StopPropagation();
        }

        void OnMouseUp(MouseUpEvent e)
        {
            if (!m_Active || !target.HasMouseCapture() || !CanStopManipulation(e))
                return;

            m_Active = false;
            target.ReleaseMouse();
            e.StopPropagation();
            PersistHandlePosition();
        }

        void UpdateElements(float handlePosition)
        {
            target.style.left = m_TargetPosition;
            UpdateElement(target.parent, handlePosition, 0);

            float verticalScrollOffset = m_Elements.Q(className: ScrollView.vScrollerUssClassName).layout.width;
            foreach (var el in m_Elements.Children())
            {
                UpdateElement(el, handlePosition, verticalScrollOffset);
            }
        }

        void UpdateElement(VisualElement el, float handlePosition, float offset)
        {
            float totalPadding = el.ElementAt(0).style.paddingLeft.value.value + el.ElementAt(0).style.paddingRight.value.value + el.ElementAt(1).style.paddingLeft.value.value + el.ElementAt(1).style.paddingRight.value.value;
            float percentage = (handlePosition + (target.style.width.value.value) / 2 - totalPadding / 2) / (target.parent.layout.width - (totalPadding + offset));

            el.ElementAt(0).style.flexGrow = percentage;
            el.ElementAt(1).style.flexGrow = 1 - percentage;
        }
    }
}