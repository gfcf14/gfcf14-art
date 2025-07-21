window.viewportHelper = {
  getDeviceType: () => {
    const width = window.innerWidth;

    if (width >= 1024) return 'desktop';
    if (width >= 768) return 'tablet';

    return 'mobile';
  },
  registerResizeCallback: (dotNetHelper) => {
    window.onresize = () => {
      dotNetHelper.invokeMethodAsync('OnResize');
    };
  }
};
