
// DllLoaderDlg.h : header file
//

#pragma once
#include "afxeditbrowsectrl.h"
#include "afxwin.h"


// CDllLoaderDlg dialog
class CDllLoaderDlg : public CDialogEx
{
// Construction
public:
	CDllLoaderDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_DLLLOADER_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedBtnLoadDll();
	afx_msg void OnEnChangeMfceditbrowseDllpath();
	CMFCEditBrowseCtrl m_mfcEditBrowseDllPath;
	CButton m_btnLoadDll;
	CMFCEditBrowseCtrl m_mfcEditBrowseFileName;
	afx_msg void OnEnChangeMfceditbrowseFilepath();
};
