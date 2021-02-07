using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserInterface : PrefabSingleton<UserInterface>
{

    [SerializeField] private Transform windowParrent = null;
    [SerializeField] private List<Window> prefabs = new List<Window>();
    private List<Window> windows = new List<Window>();

    private T GetWindow<T>() where T : Window
    {
        var window = windows.FirstOrDefault(c => c is T);
        if (window == null)
        {
            window = Instantiate(prefabs.First(c => c is T), windowParrent);
            windows.Add(window);
        }
        return window as T;
    }
    public abstract class Window : MonoBehaviour//, IPointerClickHandler
    {/*
        public Action OnShown;
        public Action OnHiden;
        protected ParaSim control;//This is our control action list. It can be used to direct access to butten presses from code
        [SerializeField] protected Canvas canvas = null;
        [SerializeField] protected Button close = null;
        [SerializeField] protected GameObject selectedOnStart = null;

        protected virtual void Awake()
        {
            canvas.gameObject.SetActive(false);
            SetUICursoreTo(selectedOnStart);
            close.onClick.AddListener(Hide);
            control = new ParaSim();
            control.UI.Cancel.performed += OnBackButton;//this is how you can subscribe to button press
        }

        protected virtual void SetUICursoreTo(GameObject target = null)
        {
            if (target != null)//trick to set selected object in UI to be able to use gamepad
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(target);
            }
        }

        protected virtual void OnDestroy()
        {
            control.UI.Cancel.performed -= OnBackButton;
        }

        protected abstract void OnBackButton(InputAction.CallbackContext input);

        public virtual void Show()
        {
            OnShown?.Invoke();
            canvas.gameObject.SetActive(true);
            control.Enable();//enabling control to be able to react to button presses 
            SetUICursoreTo(selectedOnStart);
        }

        public virtual void Hide()
        {
            OnHiden?.Invoke();
            canvas.gameObject.SetActive(false);
            control.Disable();//disabling control to stop react to button presses
        }

        public abstract void OnPointerClick(PointerEventData eventData);
        */
    }
}
